using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neuron
{
    public class NormalNeuron : Neuron
    {
        public NormalNeuron()
        {
            name = "Normal";
            description = "A normal tanh neuron";
        }


        public override double Output
        {
            get 
            { 
                return Math.Tanh(inputs.Sum(item => item.Output));
            }
        }
    }
}
