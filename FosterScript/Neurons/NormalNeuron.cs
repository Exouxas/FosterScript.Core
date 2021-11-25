using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neurons
{
    public class NormalNeuron : Neuron
    {
        public NormalNeuron()
        {
            name = "Normal";
            description = "A normal tanh neuron";
        }


        protected override double calculateOutput()
        {
            return Math.Tanh(inputs.Sum(item => item.Output));
        }
    }
}
