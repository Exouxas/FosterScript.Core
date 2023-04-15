using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.Agents
{
    /// <summary>
    /// A module that may be inserted into an Actor for added functionality
    /// </summary>
    public abstract class Module : Dependency
    {
        /*
         * Each "module" will attempt to be self-sufficient. 
         * 
         * A module can be dependent on another module, although it will not crash the software if the dependency is missing.
         * 
         * A module that is missing one or more dependencies will either:
         *      Be disabled
         *      Be removed (causing a cascading removal of modules)
         *      Cause its parent Actor to be "killed" due to weak genetics
         */

        /// <summary>
        /// Parent actor
        /// </summary>
        public Actor? Body { get; set; }

        public abstract Dictionary<string, int[]> Dependencies { get; }
        public Dictionary<string, Dependency> DependencyReferences { get; set; }

        public Module()
        {
            DependencyReferences = new();
        }

        public bool CheckDependencies(ICollection<Dependency> dependencyList)
        {
            Dictionary<string, Dependency> existingModules = dependencyList.ToDictionary(x => x.Name, x => x);
            Dictionary<string, Dependency> depRefs = new();

            foreach (string s in Dependencies.Keys)
            {
                if (!existingModules.ContainsKey(s)) 
                { 
                    return false; // Doesn't have the required module at all
                } 
                else
                {
                    if (!IsValid(Dependencies[s], existingModules[s].Version))
                    {
                        return false; // One of the modules has the wrong version
                    }
                    else
                    {
                        // Dependency exists and is valid!
                        depRefs.Add(s, existingModules[s]);
                    }
                }
            }

            // All modules exist and have a valid version
            DependencyReferences = depRefs;
            return true; 
        }

        public abstract void Think();
        public abstract void Act();
    }
}
