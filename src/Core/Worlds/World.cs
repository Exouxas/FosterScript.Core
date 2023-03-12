using System;
using System.Collections.Generic;
using System.Linq;
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

        // TODO: Asynchronously call Think() on all actors. They don't depend on each other for this action.
        private void Think()
        {
            lock (_actorLock)
            {
                foreach (Actor a in _actors)
                {
                    a.Think(new List<Actor>(_actors));
                }
            }
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
        }

        /// <summary>
        /// Progresses the world one step.
        /// </summary>
        protected void Step(){
            Think();
            Act();
        }

        public void Add(Actor a)
        {
            lock (_actorLock)
            {
                _actors.Add(a);
            }
        }
    }
}
