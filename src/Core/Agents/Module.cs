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
    public abstract class Module
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

        public abstract List<string> Dependencies { get; }
    }
}
