using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.Nodes
{
    /// <summary>
    /// Any object that gives an output, with methods for calculating and propagating
    /// </summary>
    public interface ICanSupplement
    {
        public double Output { get; }

        /// <summary>
        /// Calculates and stores value in the back to prepare for propagation
        /// </summary>
        public void Calculate();

        /// <summary>
        /// Takes stored values, and moves them out front so other nodes can use them
        /// </summary>
        public void Propagate();
    }
}
