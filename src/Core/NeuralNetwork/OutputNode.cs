using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Exit node where values will be used to drive actions
    /// </summary>
    [Serializable]
    public class OutputNode : Neuron, ICanAugment, ISerializable
    {
        /// <summary>
        /// Calculates value that module can use.
        /// </summary>
        public double Result
        {
            get
            {
                double sum = 0;
                foreach (NeuralConnection input in Inputs)
                {
                    sum += input.Output;
                }
                return Math.Tanh(sum);
            }
        }

        public List<NeuralConnection> Inputs { get; }

        protected OutputNode(string name, string description) : base(name, description)
        {
            Inputs = new List<NeuralConnection>();
        }

        protected OutputNode(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Inputs = (List<NeuralConnection>)info.GetValue(nameof(Inputs), typeof(List<NeuralConnection>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(Inputs), Inputs);
        }
    }
}
