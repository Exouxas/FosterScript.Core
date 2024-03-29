﻿using System.Runtime.Serialization;
using FosterScript.Core.Utilities;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// General neuron. Base type for the input, hidden, and output nodes.
    /// </summary>
    [Serializable]
    public abstract class Neuron : Serializable
    {
        /// <summary>
        /// Name of the neuron
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        protected string _name;

        /// <summary>
        /// Description of the neuron
        /// </summary>
        public string Description
        {
            get { return _description; }
        }
        protected string _description;

        protected Neuron(string name, string description)
        {
            _name = name;
            _description = description;
        }

        protected Neuron(SerializationInfo info, StreamingContext context)
        {
            _name = GetValue<string>(info, nameof(_name));
            _description = GetValue<string>(info, nameof(_description));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Name), Name);
            info.AddValue(nameof(Description), Description);
        }
    }
}
