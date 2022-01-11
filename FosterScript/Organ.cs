using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib
{
    /// <summary>
    /// A "module" that can be inserted into a Creature for added functionality
    /// </summary>
    public class Organ
    {
        /// <summary>
        /// Parent creature
        /// </summary>
        public Creature Body { get; set; }


    }
}
