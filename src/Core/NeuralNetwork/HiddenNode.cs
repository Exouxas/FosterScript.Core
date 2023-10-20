using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Calculating nodes used to calculate and propagate data from input to output
    /// </summary>
    [Serializable]
    public abstract class HiddenNode : InputNode, ICanAugment
    {
        public List<NeuralConnection> Inputs { get; }

        protected HiddenNode(string name, string description) : base(name, description)
        {
            Inputs = new List<NeuralConnection>();
        }

        protected HiddenNode(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Inputs = GetValue<List<NeuralConnection>>(info, nameof(Inputs));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(Inputs), Inputs);
        }
    }
}
