using FosterScript.Core.NeuralNetwork;

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
        private static object _loadLock = new();

        private FileSystemWatcher watcher;

        public static Dictionary<Type, List<Type>> LoadedClasses
        {
            get
            {
                lock (_loadLock)
                {
                    return _loadedClasses;
                }
            }
        }
        private static Dictionary<Type, List<Type>> _loadedClasses = new() 
        { 
            { typeof(object), new List<Type>() } 
        };

        public CachedLoader(string loadedFolder)
        {
            watcher = new(loadedFolder);

            watcher.Created += FileCreated;
            watcher.Deleted += FileDeleted;

            // Add subclasses of HiddenNode to the cache
            _loadedClasses.Add(typeof(HiddenNode), new List<Type>());
            foreach (Type t in typeof(HiddenNode).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(HiddenNode))))
            {
                _loadedClasses[typeof(HiddenNode)].Add(t);
            }
        }


        /// <summary>
        /// Adds a Type to be cached.
        /// </summary>
        /// <param name="t">The Type to be cached.</param>
        public void AddType(Type t)
        {
            lock (_loadLock)
            {
                LoadedClasses.Add(t, new List<Type>());
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
