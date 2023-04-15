using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using FosterScript.Core.Agents;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class World
    {
        public event Notify StepDone;
        public event Notify ThinkDone;
        public event Notify ActDone;

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
        private object _actorLock = new object();


        private List<Actor> _actorsToBeRemoved;
        private object _actorRemoveLock = new object();

        private Dictionary<Actor, Vector3> positions = new Dictionary<Actor, Vector3>();

        protected World()
        {
            lock (_actorLock)
            {
                _actors = new List<Actor>();
            }
        }

        internal void SortActors()
        {
            lock (_actorLock)
            {
                _actors = _actors.OrderByDescending(o => o.Initiative).ToList();
            }
        }

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
        protected void Step(){
            Think();
            Act();

            lock(_actorRemoveLock)
            {
                foreach (Actor a in _actorsToBeRemoved)
                {
                    _actors.Remove(a);
                    positions.Remove(a);
                }
                _actorsToBeRemoved.Clear();
            }

            StepDone?.Invoke();
        }

        public void Add(Actor a, Vector3 v)
        {
            lock (_actorLock)
            {
                _actors.Add(a);
                positions.Add(a, v);
            }
        }

        public void Add(Actor a)
        {
            Add(a, new Vector3(0, 0, 0));
        }

        public void Remove(Actor a)
        {
            lock (_actorRemoveLock)
            {
                _actorsToBeRemoved.Add(a);
            }
        }

        public abstract void Start();
        public abstract void Stop();
    }

    public delegate void Notify();
}
