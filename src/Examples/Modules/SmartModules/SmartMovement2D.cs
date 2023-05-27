using FosterScript.Core.Agents;
using FosterScript.Core.NeuralNetwork;
using System.Numerics;

namespace FosterScript.Examples.Modules.SmartModules
{
    public class SmartMovement2D : Module
    {
        #region "Inherited Properties"
        public override string Name => "SmartMovement2D";
        public override int[] Version => new int[] { 1, 0, 0 };
        #endregion

        #region "Properties"
        /// <summary>
        /// The speed of the agent.
        /// </summary>
        public double Speed { get; set; }
        #endregion

        #region "Private values"
        private Brain brain;
        private OutputNode outputSpeedNeuron;
        private OutputNode movementXNeuron;
        private OutputNode movementYNeuron;
        #endregion

        public SmartMovement2D() : base()
        {
            Dependencies.Add("SmartEnergy", new int[] { 1, 0, 0 });
            Dependencies.Add("BasicBrain", new int[] { 1, 0, 0 });
        }

        public override void Initialize()
        {
            // Add brain to local value
            brain = (Brain)DependencyReferences["BasicBrain"];

            // Add input nodes to brain
            InputNode inputSpeedNeuron = new("Speed", "Gives the hyperbolic tangent of the current speed", 0);
            inputSpeedNeuron.OnRequestOutput += (object sender, InputNeuronEventArgs e) =>
            {
                e.Output = Math.Tanh(Speed);
            };
            brain.SupplementingNodes.Add(inputSpeedNeuron);

            // Add output nodes to brain
            outputSpeedNeuron = new("Speed", "Distance of movement");
            brain.AugmentingNodes.Add(outputSpeedNeuron);

            movementXNeuron = new("Movement X", "X direction of movement");
            brain.AugmentingNodes.Add(movementXNeuron);

            movementYNeuron = new("Movement Y", "Y direction of movement");
            brain.AugmentingNodes.Add(movementYNeuron);
        }
        public override void Think()
        {
            
        }
        public override void Act()
        {
            // Move according to output neurons
            Speed = outputSpeedNeuron.Result * 10;
            float x = (float)movementXNeuron.Result;
            float y = (float)movementYNeuron.Result;
            float normalizedDistance = (float)Math.Sqrt(x * x + y * y);

            // Normalize distance
            x /= normalizedDistance;
            y /= normalizedDistance;

            // Exponentially more exhausting to move faster
            ((SmartEnergy)DependencyReferences["SmartEnergy"]).EnergyStored -= Speed * Speed;

            Body?.Move(new Vector3(x * (float)Speed, y * (float)Speed, 0));
        }
    }
}
