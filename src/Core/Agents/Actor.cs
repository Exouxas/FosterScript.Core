using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FosterScript.Core.Agents
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
        /// Don't remember what this was for... Keeping this here in case I remember in the future.
        /// </summary>
        /// <value></value>
        public string GeneticPotential { get; set; }

        public Actor(float x, float y) : this(x, y, "")
        {

        }

        public Actor(float x, float y, string geneticPotential)
        {
            Position = new Vector2(x, y);
            Modules = new List<Module>();
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