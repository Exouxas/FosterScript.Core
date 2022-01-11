using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    /// <summary>
    /// Calculating nodes used to calculate and propagate data from input to output
    /// </summary>
    public abstract class HiddenNode : InputNode, ICanAugment
    {
        public List<ICanSupplement> Inputs { get; }

        protected HiddenNode(string name, string description) : base(name, description)
        {
            Inputs = new List<ICanSupplement>();
        }
    }
}
