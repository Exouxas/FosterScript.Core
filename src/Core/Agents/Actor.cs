using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using FosterScript.Core.Worlds;

namespace FosterScript.Core.Agents
{
    /// <summary>
    /// Hard-coded AI
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// List of "parts" that alter or add to the Actors features.
        /// </summary>
        /// <value></value>
        private List<Module> Modules { get; set; }

        /// <summary>
        /// Check if modules are validated.
        /// </summary>
        private bool AreModulesValidated 
        {
            get
            {
                if (_areModulesValidated) { return true; }

                foreach(Module module in Modules)
                {
                    if (!module.CheckDependencies((ICollection<Dependency>)Modules))
                    {
                        return false;
                    }
                }

                _areModulesValidated = true;
                return _areModulesValidated;
            }
            set
            {
                _areModulesValidated = value;
            } 
        }
        private bool _areModulesValidated = false;

        /// <summary>
        /// Current priority number for the Actor. Higher means it gets activated before others.
        /// </summary>
        public int Initiative { get; }

        private World _world;

        public Actor(World world)
        {
            Modules = new List<Module>();
            _world = world;
        }

        /// <summary>
        /// Calculatory phase. Take inputs, calculate different outputs.
        /// </summary>
        public virtual void Think(List<Actor> interactibles)
        {
            if (AreModulesValidated)
            {
                foreach (Module module in Modules)
                {
                    module.Think();
                }
            }
        }

        /// <summary>
        /// Use calculated values to act upon itself and the world.
        /// </summary>
        public virtual void Act(List<Actor> interactibles)
        {
            if (AreModulesValidated)
            {
                foreach (Module module in Modules)
                {
                    module.Act();
                }
            }
        }

        /// <summary>
        /// Remove actor from the world
        /// </summary>
        public void Kill()
        {
            // Queue this actor to be removed
            _world.Remove(this);
        }

        public void Move(Vector3 v)
        {
            _world.Move(this, v);
        }

        /// <summary>
        /// Add a module to the actor.
        /// </summary>
        /// <param name="m">Module to be added.</param>
        public void AddModule(Module m){
            Modules.Add(m);
            m.Body = this;
            AreModulesValidated = false;
        }
    }
}