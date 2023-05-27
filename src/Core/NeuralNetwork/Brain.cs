using System.Runtime.Serialization;
using FosterScript.Core.Agents;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Stores and calculates nodes.
    /// </summary>
    [Serializable]
    public abstract class Brain : Module, ISerializable
    {
        public List<ICanSupplement> SupplementingNodes { get; }
        public List<ICanAugment> AugmentingNodes { get; }
        public List<NeuralConnection> NeuralConnections { get; set; }
        private object _neuralLock = new object();

        public Brain()
        {
            SupplementingNodes = new();
            AugmentingNodes = new();
            NeuralConnections = new();
        }

        protected Brain(SerializationInfo info, StreamingContext context)
        {
            SupplementingNodes = (List<ICanSupplement>)info.GetValue(nameof(SupplementingNodes), typeof(List<ICanSupplement>));
            AugmentingNodes = (List<ICanAugment>)info.GetValue(nameof(AugmentingNodes), typeof(List<ICanAugment>));
            NeuralConnections = (List<NeuralConnection>)info.GetValue(nameof(NeuralConnections), typeof(List<NeuralConnection>));
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(SupplementingNodes), SupplementingNodes);
            info.AddValue(nameof(AugmentingNodes), AugmentingNodes);
            info.AddValue(nameof(NeuralConnections), NeuralConnections);
        }


        /// <summary>
        /// Connects 'from' supplementing node to 'to' augmenting node with specified weight.
        /// </summary>
        /// <param name="from">The supplementing node.</param>
        /// <param name="to">The augmenting node.</param>
        /// <param name="weight">The weight of the connection.</param>
        public void MakeConnection(ICanSupplement from, ICanAugment to, double weight)
        {
            if (!SupplementingNodes.Contains(from) || !AugmentingNodes.Contains(to))
            {
                throw new ArgumentException("One or more of the nodes are not in the brain.");
            }

            NeuralConnections.Add(new NeuralConnection(from, to, weight));
        }

        /// <summary>
        /// Calculates the output values for all supplementing nodes in the brain.
        /// </summary>
        protected void Calculate()
        {
            foreach (var node in SupplementingNodes)
            {
                node.Calculate();
            }
        }

        /// <summary>
        /// Propagates values through the neural network from supplementing nodes to augmenting nodes.
        /// </summary>
        protected void Propagate()
        {
            foreach (var node in SupplementingNodes)
            {
                node.Propagate();
            }
        }
    }
}
