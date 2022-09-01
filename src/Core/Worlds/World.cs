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

        public void Think()
        {
            SortActors();

            foreach(Actor a in Actors){
                a.Think();
            }
        }

        public void Act()
        {
            SortActors();

            foreach(Actor a in Actors){
                a.Act();
            }
        }
    }
}
