using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neurons
{
    public class HighestNeuron : Neuron
    {
        public HighestNeuron()
        {
            name = "Highest";
            description = "Returns the max value of inputs";
        }


        protected override double calculateOutput()
        {
            return inputs.Max(item => item.Output);
        }
    }
}
