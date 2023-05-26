using FosterScript.Core.Agents;
using FosterScript.Core.NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Examples.Modules.SmartModules
{
    internal class SmartEnergy : Module
    {
        #region "Inherited Properties"
        public override string Name => "SmartEnergy";
        public override int[] Version => new int[] { 1, 0, 0 };
        #endregion

        #region "Properties"
        public double EnergyStored 
        {
            get
            {
                return _energyStored;
            }
            set
            {
                if(value <= 0)
                {
                    Body?.Kill();
                }
                _energyStored = value;
            } 
        }
        private double _energyStored;
        #endregion

        #region "Private values"
        private Brain brain = null;
        #endregion

        public SmartEnergy() : base()
        {
            Dependencies.Add("BasicBrain", new int[] { 1, 0, 0 });
        }

        public override void Initialize()
        {
            // Add brain to local value
            brain = (Brain)DependencyReferences["BasicBrain"];

            // Add input nodes to brain
            InputNode storedEnergyNeuron = new("Energy stored", "Gives the hyperbolic tangent of the amount of stored energy", 0);
            storedEnergyNeuron.OnRequestOutput += (object sender, InputNeuronEventArgs e) =>
            {
                e.Output = Math.Tanh(EnergyStored);
            };
            brain.SupplementingNodes.Add(storedEnergyNeuron);
        }

        public override void Think()
        {
            // Module only used as value storage
        }

        public override void Act()
        {
            // Module only used as value storage
        }
    }
}
