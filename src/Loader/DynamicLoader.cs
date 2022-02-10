using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FosterScript.Loader
{
    /// <summary>
    /// Loads parts and components during runtime. Specifically for loading InputNode, HiddenNode, and Organ.
    /// </summary>
    public abstract class DynamicLoader
    {
        /// <summary>
        /// Relative path to the node folder.
        /// </summary>
        /// <value>Relative path.</value>
        public string NodeFolderPath 
        { 
            get
            { 
                lock(nodeFolderLock)
                {
                    return nodeFolderPath;
                }
            } 
            set
            {
                lock(nodeFolderLock)
                {
                    nodeFolderPath = value;
                }
            } 
        }
        private string nodeFolderPath;
        private readonly object nodeFolderLock;


        /// <summary>
        /// Relative path to the organ folder.
        /// </summary>
        /// <value>Relative path.</value>
        public string OrganFolderPath 
        { 
            get
            { 
                lock(organFolderLock)
                {
                    return organFolderPath;
                }
            } 
            set
            {
                lock(organFolderLock)
                {
                    organFolderPath = value;
                }
            } 
        }
        private string organFolderPath;
        private readonly object organFolderLock;


        /// <summary>
        /// Interval in minutes. Minimum 1 minute.
        /// </summary>
        /// <value></value>
        public double Interval
        {
            get 
            { 
                return (FileCheckTimer.Interval / 1000) / 60; 
            }
            set 
            { 
                if(value > 1)
                {
                    FileCheckTimer.Interval = value * 1000 * 60; 
                }
            }
        }
        

        /// <summary>
        /// Gets value indicating whether the loader is active.
        /// </summary>
        /// <value></value>
        public bool Enabled 
        { 
            get { return FileCheckTimer.Enabled; } 
        }



        private System.Timers.Timer FileCheckTimer;
        private DateTime lastLoadedTime;


        public DynamicLoader()
        {
            organFolderLock = new object();
            nodeFolderLock = new object();

            // Load and check default folders. Use a settings file.



            // Do the dynamic loading pre-work
            FileCheckTimer = new System.Timers.Timer();
            FileCheckTimer.Interval = 1000 * 60 * 10; // 10 minutes
            FileCheckTimer.AutoReset = true;
            FileCheckTimer.Elapsed += CheckFiles;


            throw new NotImplementedException();
        }

        public DynamicLoader(string nodeFolder, string organFolder) : this() 
        { 
            lock(nodeFolderLock)
            {
                NodeFolderPath = nodeFolder;
            }

            lock(organFolderLock)
            {
                OrganFolderPath = organFolder;
            }
        }

        private void CheckFiles(object? source, ElapsedEventArgs e)
        {
            // Check folders if any of the files are older than the last time they were loaded.
            throw new NotImplementedException();


            lastLoadedTime = DateTime.Now;
        }

        
        /// <summary>
        /// Enables the folder-checking.
        /// </summary>
        public void Start()
        {
            FileCheckTimer.Start();
        }

        /// <summary>
        /// Stops the folder-checking.
        /// </summary>
        public void Stop()
        {
            FileCheckTimer.Stop();
        }
    }
}
