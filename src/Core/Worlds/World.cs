using FosterScript.Core.Agents;
using System.Numerics;
using System.Runtime.Serialization;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class World : ISerializable
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
            _currentStep = (long)info.GetValue(nameof(_currentStep), typeof(long));
            _actorsToBeRemoved = (List<Actor>)info.GetValue(nameof(_actorsToBeRemoved), typeof(List<Actor>));
            _actors = (List<Actor>)info.GetValue(nameof(_actors), typeof(List<Actor>));
            _actorRemoveLock = (object)info.GetValue(nameof(_actorRemoveLock), typeof(object));
            _actorLock = (object)info.GetValue(nameof(_actorLock), typeof(object));
            _positionsLock = (object)info.GetValue(nameof(_positionsLock), typeof(object));
            positions = (Dictionary<Actor, Vector3>)info.GetValue(nameof(positions), typeof(Dictionary<Actor, Vector3>));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
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

            Vector3 oldPosition = GetPosition(a);

            lock (_positionsLock)
            {
                if (positions.ContainsKey(a))
                {
                    positions[a] = v;
                }
            }

            ActorMoved?.Invoke(a, oldPosition, v);
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

        public abstract void Start();
        public abstract void Stop();
    }

    public delegate void Notify();
    public delegate void NotifyActorEvent(Actor actor, Vector3 vector);
    public delegate void NotifyActorMoved(Actor actor, Vector3 oldPosition, Vector3 newPosition);
}
