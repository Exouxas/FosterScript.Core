﻿using FosterScript.Core.Agents;
using FosterScript.Core.NeuralNetwork;

namespace FosterScript.Examples.Modules.SmartModules
{
    internal class SmartDigestion : Module
    {
        #region "Inherited Properties"
        public override string Name => "SmartDigestion";
        public override int[] Version => new int[] { 1, 0, 0 };
        #endregion

        #region "Properties"
        public double StoredMeat { get; set; }
        public double StoredPlant { get; set; }
        public double DigestionRate { get; set; }
        #endregion

        #region "Private values"
        private Brain brain = null;
        #endregion

        public SmartDigestion() : base()
        {
            Dependencies.Add("SmartEnergy", new int[] { 1, 0, 0 });
            Dependencies.Add("BasicBrain", new int[] { 1, 0, 0 });
        }

        public override void Initialize()
        {
            // Add brain to local value
            brain = (Brain)DependencyReferences["BasicBrain"];

            // Add input nodes to brain
            InputNode storedMeatNeuron = new("Stored meat", "Gives the hyperbolic tangent of the amount of stored meat", 0);
            storedMeatNeuron.OnRequestOutput += (object sender, InputNeuronEventArgs e) =>
            {
                e.Output = Math.Tanh(StoredMeat);
            };
            brain.SupplementingNodes.Add(storedMeatNeuron);

            InputNode storedPlantNeuron = new("Stored plant", "Gives the hyperbolic tangent of the amount of stored plant", 0);
            storedPlantNeuron.OnRequestOutput += (object sender, InputNeuronEventArgs e) =>
            {
                e.Output = Math.Tanh(StoredPlant);
            };
            brain.SupplementingNodes.Add(storedPlantNeuron);

            InputNode digestionRateNeuron = new("Digestion rate", "Gives the hyperbolic tangent of the digestion rate", 0);
            digestionRateNeuron.OnRequestOutput += (object sender, InputNeuronEventArgs e) =>
            {
                e.Output = Math.Tanh(DigestionRate);
            };
            brain.SupplementingNodes.Add(digestionRateNeuron);
        }

        public override void Think()
        {

        }

        public override void Act()
        {
            // Digest food
            if (StoredMeat > DigestionRate)
            {
                StoredMeat -= DigestionRate;
                ((Energy)DependencyReferences["Energy"]).EnergyStored += DigestionRate * 5;
            }

            if (StoredPlant > DigestionRate)
            {
                StoredPlant -= DigestionRate;
                ((Energy)DependencyReferences["Energy"]).EnergyStored += DigestionRate;
            }
        }
    }
}
