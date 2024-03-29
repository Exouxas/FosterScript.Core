﻿using System.Runtime.Serialization;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Any object that gives an output, with methods for calculating and propagating
    /// </summary>
    public interface ICanSupplement : ISerializable
    {
        /// <summary>
        /// Neural output.
        /// </summary>
        public double Output { get; }

        /// <summary>
        /// Calculates and stores value in the back to prepare for propagation
        /// </summary>
        public void Calculate();

        /// <summary>
        /// Takes stored values, and moves them out front so other nodes can use them
        /// </summary>
        public void Propagate();
    }
}
