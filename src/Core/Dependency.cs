using System.Runtime.Serialization;
using FosterScript.Core.Utilities;

namespace FosterScript.Core
{
    /// <summary>
    /// A class that some other class can be dependent on.
    /// </summary>
    [Serializable]
    public abstract class Dependency : Serializable
    {
        /// <summary>
        /// Version number.
        /// </summary>
        public abstract int[] Version { get; }

        /// <summary>
        /// Name of the dependency.
        /// </summary>
        public abstract string Name { get; }

        protected Dependency() { }

        protected Dependency(SerializationInfo info, StreamingContext context)
        {

        }

        /// <summary>
        /// Check if the provided version is compatible.
        /// General rule: index 0 changing means not backward compatible anymore.
        /// If the provided version is higher at any position, return false. Otherwise return true.
        /// </summary>
        public static bool IsValid(int[] requiredVersion, int[] providedVersion)
        {
            // Verify that both version instances exist
            if (requiredVersion is not null && providedVersion is not null) 
            {
                // Verify that there are numbers in the array
                if (requiredVersion.Length > 0 && providedVersion.Length > 0) 
                {
                    // If major version isn't the same, then it's not backwars compatible
                    if (requiredVersion[0] != providedVersion[0]) 
                    {
                        return false;
                    }

                    for (int i = 1; i < requiredVersion.Length && i < providedVersion.Length; i++)
                    {
                        // Version not high enough
                        if (requiredVersion[i] > providedVersion[i]) return false;

                        // Version is newer
                        if (requiredVersion[i] < providedVersion[i]) return true; 

                        // If neither, then check next number
                    }

                    // If both version are same, return true
                    return true; 
                }
            }

            return false;
        }
    }
}
