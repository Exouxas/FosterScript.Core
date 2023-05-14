using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Simple connection between two neurons or nodes
    /// </summary>
    [Serializable]
    public class NeuralConnection : ISerializable
    {
        public ICanSupplement From { get; }
        public ICanAugment To { get; }

        public double Weight 
        { 
            get 
            { 
                return weight; 
            } 
        }
        private double weight;

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
            this.weight = weight;

            To.Inputs.Add(this);
        }

        public NeuralConnection(SerializationInfo info, StreamingContext context)
        {
            From = (ICanSupplement)info.GetValue(nameof(From), typeof(ICanSupplement));
            To = (ICanAugment)info.GetValue(nameof(To), typeof(ICanAugment));
            weight = (double)info.GetValue(nameof(Weight), typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(From), From);
            info.AddValue(nameof(To), To);
            info.AddValue(nameof(Weight), weight);
        }
    }
}
