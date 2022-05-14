using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FosterScript.Agents
{
    /// <summary>
    /// Hard-coded AI
    /// </summary>
    public abstract class Actor
    {
        /*
         * This AI will only have base functionality. (like position, size, and colour)
         */

        /// <summary>
        /// List of "parts" that alter or add to the Actors features.
        /// </summary>
        /// <value></value>
        private List<Module> Modules { get; set; }

        /// <summary>
        /// Position in the world it's contained in. 
        /// 
        /// Might be removed and instead added by a module.
        /// </summary>
        /// <value></value>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Size of the actor, to be used in graphical implementations and interactions.
        /// 
        /// Might be removed and instead added by a module.
        /// </summary>
        /// <value></value>
        public double Radius { get; set; }

        /// <summary>
        /// Color of the actor, to be used in graphical implementations and interactions.
        /// 
        /// Might be removed and instead added by a module.
        /// </summary>
        /// <value></value>
        public System.Drawing.Color Color { get; set; }

        /// <summary>
        /// Don't remember what this was for... Keeping this here in case I remember in the future.
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Calculatory phase. Take inputs, calculate different outputs.
        /// </summary>
        public abstract void Think();

        /// <summary>
        /// Use calculated values to act upon itself and the world.
        /// </summary>
        public abstract void Act();
        
        /// <summary>
        /// Add a module to the actor.
        /// </summary>
        /// <param name="m">Module to be added.</param>
        public void AddModule(Module m){
            Modules.Add(m);
            m.Body = this;
        }
    }
}