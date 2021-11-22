using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neuron
{
    public class ReverseNeuron : Neuron
    {
        public ReverseNeuron()
        {
            name = "Reverse";
            description = "Returns the opposite of a Normal neuron";
        }


        public override double Output
        {
            get
            {
                return Math.Tanh(inputs.Sum(item => item.Output)) * -1;
            }
        }
    }
}
