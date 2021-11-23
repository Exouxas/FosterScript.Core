using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neurons
{
    public class SimilarityNeuron : Neuron
    {
        public SimilarityNeuron()
        {
            name = "Similarity";
            description = "Returns high when inputs are similar, and low when inputs are different";
        }


        public override double Output
        {
            get
            {
                double min = inputs.Min(item => item.Output);
                double max = inputs.Max(item => item.Output);
                return 4 - (max - min); // Lowest possible is -4, highest is 4, so biggest difference can be 8, which returns -4
            }
        }
    }
}
