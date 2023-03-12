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
            get { return _actors; }
        }
        private List<Actor> _actors;

        protected World()
        {
            _actors = new List<Actor>();
        }

        internal void SortActors()
        {
            _actors = _actors.OrderByDescending(o=>o.Initiative).ToList();
        }

        // TODO: Asynchronously call Think() on all actors. They don't depend on each other for this action.
        private void Think()
        {
            foreach(Actor a in _actors)
            {
                a.Think(new List<Actor>(_actors));
            }
        }

        private void Act()
        {
            SortActors();

            foreach(Actor a in _actors)
            {
                a.Act(new List<Actor>(_actors));
            }
        }

        /// <summary>
        /// Progresses the world one step.
        /// </summary>
        protected void Step(){
            Think();
            Act();
        }
    }
}
