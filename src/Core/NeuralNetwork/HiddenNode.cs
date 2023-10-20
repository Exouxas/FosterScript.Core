using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Calculating nodes used to calculate and propagate data from input to output
    /// </summary>
    [Serializable]
    public abstract class HiddenNode : InputNode, ICanAugment, ISerializable
    {
        public List<NeuralConnection> Inputs { get; }

        protected HiddenNode(string name, string description) : base(name, description)
        {
            Inputs = new List<NeuralConnection>();
        }

        protected HiddenNode(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Inputs = (List<NeuralConnection>)(info.GetValue(nameof(Inputs), typeof(List<NeuralConnection>)) ?? throw new SerializationException());
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(Inputs), Inputs);
        }
    }
}
