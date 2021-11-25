using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neurons
{
    public class LowestNeuron : Neuron
    {
        public LowestNeuron()
        {
            name = "Lowest";
            description = "Returns the min value of inputs";
        }


        protected override double calculateOutput()
        {
            return inputs.Min(item => item.Output);
        }
    }
}
