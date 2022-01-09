using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    public abstract class HiddenNode : Neuron, ICanSupplement, ICanAugment
    {
        public List<ICanSupplement> Inputs { get; }
        public double Output
        {
            get
            {
                return GetOutput();
            }
        }
        protected abstract double GetOutput();

        protected HiddenNode(string name, string description) : base(name, description)
        {
            Inputs = new List<ICanSupplement>();
        }
    }
}
