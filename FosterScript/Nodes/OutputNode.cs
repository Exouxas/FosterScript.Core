using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    public abstract class OutputNode : Neuron, ICanAugment
    {
        public abstract List<ICanSupplement> Inputs { get; }
    }
}
