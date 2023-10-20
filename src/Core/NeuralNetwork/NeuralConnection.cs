using System.Runtime.Serialization;
using FosterScript.Core.Utilities;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Simple connection between two neurons or nodes
    /// </summary>
    [Serializable]
    public class NeuralConnection : Serializable
    {
        /// <summary>
        /// Supplementing node
        /// </summary>
        public ICanSupplement From { get; }

        /// <summary>
        /// Receiving node
        /// </summary>
        public ICanAugment To { get; }

        /// <summary>
        /// Weight of the connection
        /// </summary>
        public double Weight 
        { 
            get 
            { 
                return weight; 
            } 
        }
        private readonly double weight;

        /// <summary>
        /// Output of the connection
        /// </summary>
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
            From = GetValue<ICanSupplement>(info, nameof(From));
            To = GetValue<ICanAugment>(info, nameof(To));
            weight = GetValue<double>(info, nameof(Weight));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(From), From);
            info.AddValue(nameof(To), To);
            info.AddValue(nameof(Weight), weight);
        }
    }
}
