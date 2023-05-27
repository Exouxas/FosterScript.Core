using System.Runtime.Serialization;

namespace FosterScript.Core
{
    /// <summary>
    /// A class that some other class can be dependent on.
    /// </summary>
    [Serializable]
    public abstract class Dependency : ISerializable
    {
        /// <summary>
        /// Version number.
        /// </summary>
        public abstract int[] Version { get; }

        public abstract string Name { get; }

        protected Dependency() { }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }

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
            if (requiredVersion is not null && providedVersion is not null) // Verify that both version instances exist
            {
                if (requiredVersion.Length > 0 && providedVersion.Length > 0) // Verify that there are numbers in the array
                {
                    if (requiredVersion[0] != providedVersion[0]) // If major version isn't the same, then it's not backwars compatible
                    {
                        return false;
                    }

                    for (int i = 1; i < requiredVersion.Length && i < providedVersion.Length; i++)
                    {
                        if (requiredVersion[i] > providedVersion[i]) return false; // Version not high enough

                        if (requiredVersion[i] < providedVersion[i]) return true; // Version is newer

                        // If neither, then check next number
                    }

                    return true; // If both version are same, return true
                }
            }

            return false;
        }
    }
}
