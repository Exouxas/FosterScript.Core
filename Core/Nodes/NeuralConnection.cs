using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Core.Nodes
{
    /// <summary>
    /// Simple connection between two nerons or nodes
    /// </summary>
    public class NeuralConnection
    {
        public ICanSupplement From { get; }
        public ICanAugment To { get; }

        public double Weight { get; }

        public double Output
        {
            get 
            { 
                return From.Output * Weight;
            }
        }


        public NeuralConnection(ICanSupplement from, ICanAugment to, double weight)
        {
            From = from;
            To = to;

            if(weight < -4)
            {
                Weight = -4;
            }
            else if(weight > 4)
            {
                Weight = 4;
            }
            else
            {
                Weight = weight;
            }

            To.Inputs.Add(this);
        }
    }
}
