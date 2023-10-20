using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Simple connection between two neurons or nodes
    /// </summary>
    [Serializable]
    public class NeuralConnection : ISerializable
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
            From = (ICanSupplement)(info.GetValue(nameof(From), typeof(ICanSupplement)) ?? throw new SerializationException());
            To = (ICanAugment)(info.GetValue(nameof(To), typeof(ICanAugment)) ?? throw new SerializationException());
            weight = (double)(info.GetValue(nameof(Weight), typeof(double)) ?? throw new SerializationException());
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(From), From);
            info.AddValue(nameof(To), To);
            info.AddValue(nameof(Weight), weight);
        }
    }
}
