using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    /// <summary>
    /// Exit node where values will be used to drive actions
    /// </summary>
    public abstract class OutputNode : Neuron, ICanAugment
    {
        public List<NeuralConnection> Inputs { get; }

        protected OutputNode(string name, string description) : base(name, description)
        {
            Inputs = new List<NeuralConnection>();
        }
    }
}
