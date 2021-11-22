using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neuron
{
    public class HypocondriacNeuron : Neuron
    {
        public HypocondriacNeuron()
        {
            name = "Hypocondriac";
            description = "Returns the extreme of the inputs";
        }


        public override double Output
        {
            get
            {
                double sum = inputs.Sum(item => item.Output);
                return (sum / Math.Abs(sum)) * 4;
            }
        }
    }
}
