using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FosterScript
{
    /// <summary>
    /// Hard-coded AI
    /// </summary>
    public abstract class Actor
    {
        /*
         * Each "module" will attempt to be self-sufficient. 
         * 
         * A module can be dependent on another module, although it will not crash the software if the dependency is missing.
         * 
         * This AI will only have base functionality. (like position, size, and colour)
         */

        private List<Module> Modules { get; set; }

        public Vector2 Position { get; set; }

        public double Radius { get; set; }

        public System.Drawing.Color Color { get; set; }

        public string GeneticPotential { get; set; }

        public Actor(float x, float y)
        {
            Position = new Vector2(x, y);
            Modules = new List<Module>();
        }

        public Actor(float x, float y, string geneticPotential): this(x, y)
        {
            GeneticPotential = geneticPotential;
        }

        public abstract void Think();

        public abstract void Act();
        
        public void AddModule(Module m){
            Modules.Add(m);
            m.Body = this;
        }
    }
}