using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neuron
{
    public class NegativeNeuron : Neuron
    {
        public NegativeNeuron()
        {
            name = "Negative";
            description = "Returns -4";
        }


        public override double Output
        {
            get
            {
                return -4d;
            }
        }
    }
}
