using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Nodes that provide input to the network
    /// </summary>
    [Serializable]
    public class InputNode : Neuron, ICanSupplement, ISerializable
    {
        public delegate void OutputRequestHandler(object sender, InputNeuronEventArgs e);
        public event OutputRequestHandler? OnRequestOutput;

        public double Output
        {
            get
            {
                return output;
            }
        }
        private double output;

        private double storedOutput;

        protected InputNode(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            output = (double)info.GetValue(nameof(Output), typeof(double));
            storedOutput = (double)info.GetValue(nameof(storedOutput), typeof(double));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(Output), Output);
            info.AddValue(nameof(storedOutput), storedOutput);
        }

        /// <summary>
        /// Calculates and stores value in the back to prepare for propagation
        /// </summary>
        public void Calculate()
        {
            InputNeuronEventArgs args = new();
            if (OnRequestOutput != null)
            {
                OnRequestOutput?.Invoke(this, args);
            }

            storedOutput = args.Output;
        }

        /// <summary>
        /// Takes stored values, and moves them out front so other nodes can use them
        /// </summary>
        public void Propagate()
        {
            output = storedOutput;
        }

        public InputNode(string name, string description) : this(name, description, 0)
        {
            
        }

        public InputNode(string name, string description, double output) : base(name, description)
        {
            this.output = output;
        }
    }

    public class InputNeuronEventArgs : EventArgs
    {
        public double Output { get; set; }

        public InputNeuronEventArgs()
        {
            Output = 0;
        }
    }
}
