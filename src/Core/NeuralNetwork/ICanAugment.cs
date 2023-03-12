using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Any object that takes inputs, and uses them for something
    /// </summary>
    public interface ICanAugment
    {
        public abstract List<NeuralConnection> Inputs { get; }
    }
}
