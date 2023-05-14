using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FosterScript.Core
{
    /// <summary>
    /// Implements a listener to load and cache classes from a selected folder.
    /// </summary>
    public class CachedLoader
    {
        /// <summary>
        /// Enable or disable the loader.
        /// </summary>
        public bool Enabled => watcher.EnableRaisingEvents;
        private object _loadLock;

        private FileSystemWatcher watcher;
        private Dictionary<Type, List<Type>> loadedClasses = new();

        public CachedLoader(string loadedFolder)
        {
            loadedClasses.Add(typeof(object), new List<Type>());

            watcher = new(loadedFolder);

            watcher.Created += FileCreated;
            watcher.Deleted += FileDeleted;
        }


        /// <summary>
        /// Adds a Type to be cached.
        /// </summary>
        /// <param name="t">The Type to be cached.</param>
        public void AddType(Type t)
        {
            lock (_loadLock)
            {
                loadedClasses.Add(t, new List<Type>());
            }
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            // TODO: Load the file and add it to the cache
            throw new NotImplementedException();
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            // TODO: Unload the file and remove it from the cache
            throw new NotImplementedException();
        }
    }
}
