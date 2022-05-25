using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Exit node where values will be used to drive actions
    /// </summary>
    public class OutputNode : Neuron, ICanAugment
    {
        /// <summary>
        /// Calculates value that module can use.
        /// </summary>
        public double Result
        {
            get 
            { 
                return Math.Tanh(Inputs.Sum()); 
            }
        }

        public List<NeuralConnection> Inputs { get; }

        protected OutputNode(string name, string description) : base(name, description)
        {
            Inputs = new List<NeuralConnection>();
        }
    }
}
