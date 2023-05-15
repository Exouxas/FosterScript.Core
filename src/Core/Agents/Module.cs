using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace FosterScript.Core.Agents
{
    /// <summary>
    /// A module that may be inserted into an Actor for added functionality
    /// </summary>
    [Serializable]
    public abstract class Module : Dependency, ISerializable
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

        public Dictionary<string, int[]> Dependencies { get; }
        public Dictionary<string, Module> DependencyReferences { get; set; }

        public Module()
        {
            Dependencies = new();
            DependencyReferences = new();
        }

        protected Module(SerializationInfo info, StreamingContext context) : this()
        {
            Body = (Actor?)info.GetValue(nameof(Body), typeof(Actor));
            Dependencies = (Dictionary<string, int[]>)info.GetValue(nameof(Dependencies), typeof(Dictionary<string, int[]>));
            DependencyReferences = (Dictionary<string, Module>)info.GetValue(nameof(DependencyReferences), typeof(Dictionary<string, Module>));
        }

        public bool CheckDependencies(List<Module> dependencyList)
        {
            Dictionary<string, Module> existingModules = dependencyList.ToDictionary(x => x.Name, x => x);
            Dictionary<string, Module> depRefs = new();

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

        public abstract void Initialize();
        public abstract void Think();
        public abstract void Act();

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Body), Body);
            info.AddValue(nameof(Dependencies), Dependencies);
            info.AddValue(nameof(DependencyReferences), DependencyReferences);
        }
    }
}
