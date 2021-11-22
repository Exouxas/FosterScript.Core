using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neuron
{
    public class HighestNeuron : Neuron
    {
        public HighestNeuron()
        {
            name = "Highest";
            description = "Returns the max value of inputs";
        }


        public override double Output
        {
            get
            {
                return inputs.Max(item => item.Output);
            }
        }
    }
}
