using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FosterScript.Core
{
    /// <summary>
    /// A class that some other class can be dependent on.
    /// </summary>
    public abstract class Dependency
    {
        /// <summary>
        /// Version number.
        /// </summary>
        public abstract int[] Version { get; }

        /// <summary>
        /// Check if the provided version is compatible.
        /// General rule: index 0 changing means not backward compatible anymore.
        /// If the provided version is higher at any position, return false. Otherwise return true.
        /// </summary>
        public virtual bool IsValid(int[] version)
        {
            if(Version is not null && version is not null) // Verify that both version instances exist
            {
                if(Version.Length > 0 && version.Length > 0) // Verify that there are numbers in the array
                {
                    if(Version[0] != version[0]) // If major version isn't the same, then it's not backwars compatible
                    {
                        return false;
                    }

                    for(int i = 1; i < Version.Length && i < version.Length; i++) // V > v, then the implementation is newer and valid
                    {
                        if(Version[i] > version[i]) return true;

                        if(Version[i] < version[i]) return false;
                    }

                    return true; // If both version are same, return true
                }
            }

            return false;
        }
    }
}