using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neurons
{
    public class PositiveNeuron : Neuron
    {
        public PositiveNeuron()
        {
            name = "Positive";
            description = "Returns 4";
        }


        protected override double calculateOutput()
        {
            return 4d;
        }
    }
}
