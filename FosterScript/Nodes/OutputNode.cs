using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    public abstract class OutputNode : Neuron, ICanAugment
    {
        public List<ICanSupplement> Inputs { get; }

        protected OutputNode(string name, string description) : base(name, description)
        {
            Inputs = new List<ICanSupplement>();
        }
    }
}
