using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.Nodes
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

        public NeuralConnection(byte[] bin, Dictionary<ICanSupplement> from, Dictionary<ICanAugment> to)
        {
            int requiredSize = 8;
            if(bin.Length != requiredSize) // Needs to be 64 bits total
            {
                throw new Exception("Not correct amount of bytes. Expected "+ requiredSize + " bytes, but received " + bin.Length);
            }

            // Logic for searching for link points (neurons)
            throw new NotImplementedException();


        }

        public byte[] ToBinary()
        {
            // Logic for converting this object to binary.
            throw new NotImplementedException();
        }
    }
}
