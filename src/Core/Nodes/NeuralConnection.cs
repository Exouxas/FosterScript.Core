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
    public class NeuralConnection : IEnumerable<double>
    {
        public ICanSupplement From { get; }
        public ICanAugment To { get; }

        public double Weight 
        { 
            get
            {
                return savedWeight;
            }
        }
        private short weight;
        private double savedWeight;

        public double Output
        {
            get 
            { 
                return From.Output * Weight;
            }
        }


        public NeuralConnection(ICanSupplement from, ICanAugment to, short weight)
        {
            From = from;
            To = to;
            this.weight = weight;
            savedWeight = weight / 8192d;

            To.Inputs.Add(this);
        }

        public NeuralConnection(byte[] bin, Dictionary<ushort, ICanSupplement> from, Dictionary<ushort, ICanAugment> to)
        {
            int requiredSize = 6;
            if(bin.Length != requiredSize) // Needs to be 48 bits total
            {
                throw new Exception("Not correct amount of bytes. Expected "+ (requiredSize * 8) + " bits, but received " + (bin.Length * 8) + " bits");
            }

            // Logic for searching for link points (neurons)
            throw new NotImplementedException();


        }

        public IEnumerator GetEnumerator()
        {
            return Output;
        }

        public byte[] ToBinary()
        {
            // Logic for converting this object to binary.
            throw new NotImplementedException();
        }
    }
}