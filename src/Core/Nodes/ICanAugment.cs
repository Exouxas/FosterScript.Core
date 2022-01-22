using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Core.Nodes
{
    /// <summary>
    /// Any object that takes inputs, and uses them for something
    /// </summary>
    public interface ICanAugment
    {
        abstract List<NeuralConnection> Inputs { get; }
    }
}
