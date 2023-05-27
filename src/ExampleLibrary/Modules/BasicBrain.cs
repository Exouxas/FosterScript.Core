using FosterScript.Core.NeuralNetwork;

namespace FosterScript.Examples.Modules
{
    public class BasicBrain : Brain
    {
        public override int[] Version { get; } = { 1, 0, 0 };

        public override string Name { get; } = "BasicBrain";

        private readonly Random random = new();


        /// <summary>
        /// Initializes the basic brain.
        /// </summary>
        public override void Initialize()
        {
            // No initialization needed
        }

        /// <summary>
        /// Invokes the action for the brain
        /// </summary>
        public override void Act()
        {
            // Chance for random mutation in brain structure
            if (random.NextDouble() < 0.01)
            {
                double chance = random.NextDouble();
                // Add a new connection
                if (chance < 0.25)
                {
                    // Get a random node
                    var from = SupplementingNodes[random.Next(SupplementingNodes.Count)];
                    var to = AugmentingNodes[random.Next(AugmentingNodes.Count)];
                    // Make sure the connection doesn't already exist
                    if (!NeuralConnections.Any(c => c.From == from && c.To == to))
                    {
                        // Make the connection
                        MakeConnection(from, to, random.NextDouble() * 2 - 1);
                    }
                }
                // Remove a connection
                else if (chance < 0.5)
                {
                    // Make sure there are connections to remove
                    if (NeuralConnections.Count > 0)
                    {
                        // Remove a random connection
                        NeuralConnections.RemoveAt(random.Next(NeuralConnections.Count));
                    }
                }
                // Add new node
                else if (chance < 0.75)
                {

                }
                // Remove node
                else
                {

                }
            }
        }

        /// <summary>
        /// Propagates signals through the network and calculates the output
        /// </summary>
        public override void Think()
        {
            Propagate();
            Calculate();
        }
    }
}