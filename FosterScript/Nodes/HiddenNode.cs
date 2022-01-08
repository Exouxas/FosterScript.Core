using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    public abstract class HiddenNode : Neuron, ICanSupplement, ICanAugment
    {
        public abstract List<ICanSupplement> Inputs { get; }
        public abstract double Output { get; }
    }
}
