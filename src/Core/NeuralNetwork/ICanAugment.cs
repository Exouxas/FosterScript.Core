using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Any object that takes inputs, and uses them for something
    /// </summary>
    public interface ICanAugment : ISerializable
    {
        /// <summary>
        /// Neural inputs.
        /// </summary>
        public abstract List<NeuralConnection> Inputs { get; }
    }
}
