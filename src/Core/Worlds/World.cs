using FosterScript.Core.Agents;
using System.Numerics;
using System.Runtime.Serialization;
using FosterScript.Core.Utilities;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class World : Serializable
    {
        /// <summary>
        /// A whole step has been completed.
        /// </summary>
        public event Notify? StepDone;

        /// <summary>
        /// The preliminary think phase has been completed.
        /// </summary>
        public event Notify? ThinkDone;

        /// <summary>
        /// The action phase has been completed.
        /// </summary>
        public event Notify? ActDone;

        /// <summary>
        /// An actor has been killed.
        /// </summary>
        public event NotifyActorEvent? ActorKilled;

        /// <summary>
        /// An actor has been added.
        /// </summary>
        public event NotifyActorEvent? ActorAdded;

        /// <summary>
        /// An actor has been moved.
        /// </summary>
        public event NotifyActorMoved? ActorMoved;

        /// <summary>
        /// The world bounds. If this value is null, the world is unbounded. If any of the values are 0 or lower, they will be set to a very small value.
        /// </summary>
        public Vector3? WorldBounds
        {
            get => _worldBounds;
            set
            {
                if (value != null)
                {
                    float minimum = 0.000000001f;

                    _worldBounds = new Vector3(
                        Math.Max(value.Value.X, minimum),
                        Math.Max(value.Value.Y, minimum),
                        Math.Max(value.Value.Z, minimum)
                        );
                }
                else
                {
                    _worldBounds = null;
                }
            }
        }
        private Vector3? _worldBounds = null;

        /// <summary>
        /// Whether the world wraps around.
        /// </summary>
        public bool WorldWrap { get; set; } = false;

        /// <summary>
        /// Get the current step.
        /// </summary>
        public long CurrentStep
        {
            get
            {
                return _currentStep;
            }
        }
        private long _currentStep = 0;

        /// <summary>
        /// A copy of the list of all actors in the world.
        /// </summary>
        public List<Actor> Actors
        {
            get
            {
                List<Actor> actorsCopy;

                lock (_actorLock)
                {
                    actorsCopy = new List<Actor>(_actors);
                }

                return new List<Actor>(actorsCopy);
            }
        }
        private List<Actor> _actors;
        private readonly object _actorLock = new();


        private readonly List<Actor> _actorsToBeRemoved;
        private readonly object _actorRemoveLock = new();

        private readonly Dictionary<Actor, Vector3> positions = new();
        private readonly object _positionsLock = new();

        protected World()
        {
            _actorsToBeRemoved = new();

            lock (_actorLock)
            {
                _actors = new List<Actor>();
            }
        }

        internal World(SerializationInfo info, StreamingContext context)
        {
            _currentStep = GetValue<long>(info, nameof(_currentStep));
            _actorsToBeRemoved = GetValue<List<Actor>>(info, nameof(_actorsToBeRemoved));
            _actors = GetValue<List<Actor>>(info, nameof(_actors));
            _actorRemoveLock = GetValue<object>(info, nameof(_actorRemoveLock));
            _actorLock = GetValue<object>(info, nameof(_actorLock));
            _positionsLock = GetValue<object>(info, nameof(_positionsLock));
            positions = GetValue<Dictionary<Actor, Vector3>>(info, nameof(positions));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(_currentStep), _currentStep);
            info.AddValue(nameof(_actorsToBeRemoved), _actorsToBeRemoved);
            info.AddValue(nameof(_actors), _actors);
            info.AddValue(nameof(_actorRemoveLock), _actorRemoveLock);
            info.AddValue(nameof(_actorLock), _actorLock);
            info.AddValue(nameof(_positionsLock), _positionsLock);
            info.AddValue(nameof(positions), positions);
        }

        /// <summary>
        /// Sorts the actors by initiative.
        /// </summary>
        internal void SortActors()
        {
            lock (_actorLock)
            {
                _actors = _actors.OrderByDescending(o => o.Initiative).ToList();
            }
        }

        /// <summary>
        /// Cause all actors to think.
        /// </summary>
        private void Think()
        {
            lock (_actorLock)
            {
                Parallel.ForEach(_actors, a =>
                {
                    a.Think(new List<Actor>(_actors));
                });
            }

            ThinkDone?.Invoke();
        }

        /// <summary>
        /// Cause all actors to act.
        /// </summary>
        private void Act()
        {
            SortActors();

            lock (_actorLock)
            {
                foreach (Actor a in _actors)
                {
                    a.Act(new List<Actor>(_actors));
                }
            }

            ActDone?.Invoke();
        }

        /// <summary>
        /// Progresses the world one step.
        /// </summary>
        protected void Step()
        {
            _currentStep++;
            Think();
            Act();

            lock (_actorRemoveLock)
            {
                foreach (Actor a in _actorsToBeRemoved)
                {
                    Vector3 position = GetPosition(a);

                    _actors.Remove(a);
                    positions.Remove(a);
                    ActorKilled?.Invoke(a, position);
                }
                _actorsToBeRemoved.Clear();
            }

            StepDone?.Invoke();
        }

        /// <summary>
        /// Add actor to world
        /// </summary>
        /// <param name="a">Actor to be added</param>
        /// <param name="v">Location the actor will be added to</param>
        public void Add(Actor a, Vector3 v)
        {
            lock (_actorLock)
            {
                _actors.Add(a);
            }
            lock (_positionsLock)
            {
                positions.Add(a, v);
            }

            ActorAdded?.Invoke(a, v);
        }

        /// <summary>
        /// Add actor to world
        /// </summary>
        /// <param name="a">Actor to be added</param>
        public void Add(Actor a)
        {
            Add(a, new Vector3(0, 0, 0));
        }

        /// <summary>
        /// Add actor to removal queue
        /// </summary>
        /// <param name="a">Actor to be removed</param>
        public void Remove(Actor a)
        {
            lock (_actorRemoveLock)
            {
                _actorsToBeRemoved.Add(a);
            }
        }

        /// <summary>
        /// Find position of an actor
        /// </summary>
        /// <param name="a">The actor you want to get the position of</param>
        /// <returns>Position of the actor</returns>
        public Vector3 GetPosition(Actor a)
        {
            lock (_positionsLock)
            {
                if (positions.ContainsKey(a))
                {
                    return positions[a];
                }

                else
                {
                    return new Vector3();
                }
            }
        }

        /// <summary>
        /// Move actor to a specific position
        /// </summary>
        /// <param name="a">Actor to be moved</param>
        /// <param name="v">The location the actor will be moved to</param>
        public void MoveTo(Actor a, Vector3 v)
        {
            if (float.IsNaN(v.X) || float.IsNaN(v.Y) || float.IsNaN(v.Z))
            {
                throw new ArgumentException("Vector3 cannot contain NaN values");
            }

            Vector3 newPosition = v;

            if (WorldBounds != null)
            {
                float x = newPosition.X;
                float y = newPosition.Y;
                float z = newPosition.Z;

                if (WorldWrap)
                {
                    x -= (float)Math.Floor(x / WorldBounds.Value.X) * WorldBounds.Value.X;
                    y -= (float)Math.Floor(y / WorldBounds.Value.Y) * WorldBounds.Value.Y;
                    z -= (float)Math.Floor(z / WorldBounds.Value.Z) * WorldBounds.Value.Z;
                }
                else
                {
                    x = Math.Clamp(x, 0, WorldBounds.Value.X);
                    y = Math.Clamp(y, 0, WorldBounds.Value.Y);
                    z = Math.Clamp(z, 0, WorldBounds.Value.Z);
                }

                newPosition = new Vector3(x, y, z);
            }

            Vector3 oldPosition = GetPosition(a);

            lock (_positionsLock)
            {
                if (positions.ContainsKey(a))
                {
                    positions[a] = newPosition;
                }
            }

            ActorMoved?.Invoke(a, oldPosition, newPosition);
        }

        /// <summary>
        /// Move actor in a direction
        /// </summary>
        /// <param name="a">Actor to be moved</param>
        /// <param name="v">Direction and distance the actor will be moved</param>
        public void Move(Actor a, Vector3 v)
        {
            Vector3 oldPosition = GetPosition(a);

            MoveTo(a, oldPosition + v);
        }

        /// <summary>
        /// Get actors within range of the given center position and radius.
        /// </summary>
        /// <param name="center">The center position used for calculating the radius.</param>
        /// <param name="radius">The radius used for calculating the range from the center position.</param>
        /// <returns>A collection of actors within the range of the center position.</returns>
        public ICollection<Target> GetActorsInArea(Vector3 center, float radius)
        {
            List<Target> actorsInArea = new();

            lock (_actorLock)
            {
                foreach (Actor a in _actors)
                {
                    float distance = Vector3.Distance(center, GetPosition(a));
                    if (distance <= radius)
                    {
                        actorsInArea.Add(new Target(a, distance));
                    }
                }
            }

            return actorsInArea;
        }


        public abstract void Start();
        public abstract void Stop();
    }

    public delegate void Notify();
    public delegate void NotifyActorEvent(Actor actor, Vector3 vector);
    public delegate void NotifyActorMoved(Actor actor, Vector3 oldPosition, Vector3 newPosition);
}
