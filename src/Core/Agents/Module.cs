﻿using System;
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
         */

        /// <summary>
        /// Parent actor
        /// </summary>
        public abstract Actor Body { get; set; }

        public abstract Dictionary<string, int[]> Dependencies { get; }

        public bool CheckDependencies(ICollection<Dependency> dependencyList)
        {
            Dictionary<string, int[]> existingModules = dependencyList.ToDictionary(x => x.Name, x => x.Version);

            foreach (string s in Dependencies.Keys)
            {
                if (!existingModules.ContainsKey(s)) 
                { 
                    return false; // Doesn't have the required module at all
                } 
                else
                {
                    if (!IsValid(Dependencies[s], existingModules[s]))
                    {
                        return false; // One of the modules has the wrong version
                    }
                }
            }

            return true; // All modules exist and have a valid version
        }
    }
}
