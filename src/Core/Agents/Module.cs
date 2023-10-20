using System.Runtime.Serialization;

namespace FosterScript.Core.Agents
{
    /// <summary>
    /// A module that may be inserted into an Actor for added functionality
    /// </summary>
    [Serializable]
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

        /// <summary>
        /// List of dependencies with both names and version numbers
        /// </summary>
        public Dictionary<string, int[]> Dependencies { get; }

        /// <summary>
        /// References to dependencies
        /// </summary>
        public Dictionary<string, Module> DependencyReferences { get; set; }

        public Module()
        {
            Dependencies = new();
            DependencyReferences = new();
        }

        protected Module(SerializationInfo info, StreamingContext context) : this()
        {
            Body = GetValue<Actor>(info, nameof(Body));
            Dependencies = GetValue<Dictionary<string, int[]>>(info, nameof(Dependencies));
            DependencyReferences = GetValue<Dictionary<string, Module>>(info, nameof(DependencyReferences));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Body), Body);
            info.AddValue(nameof(Dependencies), Dependencies);
            info.AddValue(nameof(DependencyReferences), DependencyReferences);
        }

        /// <summary>
        /// Check if the module is valid for the given version
        /// </summary>
        /// <param name="dependencyList">List of modules</param>
        /// <returns></returns>
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

        /// <summary>
        /// Run module initialization
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Execute calculations that don't act on the world
        /// </summary>
        public abstract void Think();

        /// <summary>
        /// Use calculations to act on the world
        /// </summary>
        public abstract void Act();
    }
}
