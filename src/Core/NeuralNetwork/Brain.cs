using FosterScript.Core.Agents;
using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Stores and calculates nodes.
    /// </summary>
    [Serializable]
    public abstract class Brain : Module, ISerializable
    {
        /// <summary>
        /// Collection of all nodes that can output data to other nodes.
        /// </summary> 
        public List<ICanSupplement> SupplementingNodes { get; }

        /// <summary>
        /// Collection of all nodes that receive data.
        /// </summary> 
        public List<ICanAugment> AugmentingNodes { get; }

        /// <summary>
        /// Collection of connections between nodes in this brain.
        /// </summary> 
        public List<NeuralConnection> NeuralConnections { get; set; }
        private readonly object _neuralLock = new();

        public Brain()
        {
            SupplementingNodes = new();
            AugmentingNodes = new();
            NeuralConnections = new();
        }

        /// <summary>
        /// Initializes a new instance of the Brain class with deserialized data. 
        /// </summary>    
        /// <param name="info">The stream of serialized data.</param>
        /// <param name="context">The current deserialization context.</param>
        protected Brain(SerializationInfo info, StreamingContext context)
        {
            SupplementingNodes = (List<ICanSupplement>)(info.GetValue(nameof(SupplementingNodes), typeof(List<ICanSupplement>)) ?? throw new SerializationException());
            AugmentingNodes = (List<ICanAugment>)(info.GetValue(nameof(AugmentingNodes), typeof(List<ICanAugment>)) ?? throw new SerializationException());
            NeuralConnections = (List<NeuralConnection>)(info.GetValue(nameof(NeuralConnections), typeof(List<NeuralConnection>)) ?? throw new SerializationException());
        }

        /// <summary>
        /// Populates a SerializationInfo instance with the data required to serialize the Brain.
        /// </summary>
        /// <param name="info">The stream of serialized data.</param>
        /// <param name="context">The current serialization context.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(SupplementingNodes), SupplementingNodes);
            info.AddValue(nameof(AugmentingNodes), AugmentingNodes);
            info.AddValue(nameof(NeuralConnections), NeuralConnections);
        }

        /// <summary>
        /// Connects 'from' supplementing node 'to' augmenting node with specified weight.
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
