using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.Nodes
{
    /// <summary>
    /// Nodes that provide input to the network
    /// </summary>
    public class InputNode : Neuron, ICanSupplement
    {
        public delegate void OutputRequestHandler(object sender, InputNeuronEventArgs e);
        public event OutputRequestHandler OnRequestOutput;

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
            InputNeuronEventArgs args = new InputNeuronEventArgs();
            if(OnRequestOutput != null)
            {
                OnRequestOutput(this, args);
            }
            
            storedOutput = args.Output;
        }

        /// <summary>
        /// Takes stored values, and moves them out front so other nodes can use them
        /// </summary>
        public void Propagate()
        {
            output = storedOutput;
        }

        protected InputNode(string name, string description) : base(name, description)
        {

        }
    }

    public class InputNeuronEventArgs : EventArgs
    {
        public double Output { get; set; }

        public InputNeuronEventArgs()
        {
            Output = 0;
        }
    }
}
