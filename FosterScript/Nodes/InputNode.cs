using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    /// <summary>
    /// Nodes that provide input to the network
    /// </summary>
    public abstract class InputNode : Neuron, ICanSupplement
    {
        public double Output 
        {
            get
            {
                return output;
            } 
        }
        private double output;

        private double storedOutput;

        /// <summary>
        /// Calculates and stores value in the back to prepare for propagation
        /// </summary>
        public void Calculate()
        {
            storedOutput = GetOutput();
        }

        /// <summary>
        /// Takes stored values, and moves them out front so other nodes can use them
        /// </summary>
        public void Propagate()
        {
            output = storedOutput;
        }

        /// <summary>
        /// Method used when running Calculate()
        /// </summary>
        /// <returns>Should end up with a value from -1 to 1</returns>
        protected abstract double GetOutput();

        protected InputNode(string name, string description) : base(name, description)
        {

        }
    }
}
