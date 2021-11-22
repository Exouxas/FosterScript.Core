using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neuron
{
    public class LowestNeuron : Neuron
    {
        public LowestNeuron()
        {
            name = "Lowest";
            description = "Returns the min value of inputs";
        }


        public override double Output
        {
            get
            {
                return inputs.Min(item => item.Output);
            }
        }
    }
}
