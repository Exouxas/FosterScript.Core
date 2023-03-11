using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class World
    {
        public List<Actor> Actors { get; }

        protected World()
        {
            Actors = new List<Actor>();
        }

        internal void SortActors()
        {
            Actors = Actors.OrderByDescending(o=>o.Initiative).ToList();
        }

        // TODO: Asynchronously call Think() on all actors. They don't depend on each other for this action.
        private void Think()
        {
            foreach(Actor a in Actors){
                a.Think();
            }
        }

        private void Act()
        {
            SortActors();

            foreach(Actor a in Actors){
                a.Act();
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
