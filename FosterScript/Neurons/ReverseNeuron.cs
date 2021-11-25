using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neurons
{
    public class ReverseNeuron : Neuron
    {
        public ReverseNeuron()
        {
            name = "Reverse";
            description = "Returns the opposite of a Normal neuron";
        }


        protected override double calculateOutput()
        {
            return Math.Tanh(inputs.Sum(item => item.Output)) * -1;
        }
    }
}
