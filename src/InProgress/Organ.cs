using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript
{
    /// <summary>
    /// A "module" that can be inserted into a Creature for added functionality
    /// </summary>
    public abstract class Organ
    {
        /// <summary>
        /// Parent creature
        /// </summary>
        public abstract Creature Body { get; set; }


    }
}
