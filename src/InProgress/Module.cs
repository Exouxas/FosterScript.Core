using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript
{
    /// <summary>
    /// A module that may be inserted into an Actor for added functionality
    /// </summary>
    public abstract class Module
    {
        /// <summary>
        /// Parent actor
        /// </summary>
        public abstract Actor Body { get; set; }


    }
}
