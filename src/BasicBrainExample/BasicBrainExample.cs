using FosterScript.Core.Agents;
using FosterScript.Core.Worlds;
using FosterScript.Examples.Modules;
using FosterScript.Examples.Modules.SmartModules;

namespace FosterScript.Examples
{
    public static class BasicBrainExample
    {
        static readonly IndefiniteWorld world = new(500);
        public static void Main(string[] args)
        {
            Console.WriteLine("Indefinite World Example");

            Random random = new();

            Console.WriteLine("Creating actors");
            for (int i = 0; i < 3; i++)
            {
                Actor actor = new(world);
                List<Module> modules = new List<Module>();

                SmartDigestion smartDigestion = new();
                smartDigestion.DigestionRate = random.NextDouble() * 2;
                smartDigestion.StoredMeat = random.NextDouble() * 5;
                smartDigestion.StoredPlant = random.NextDouble() * 5;
                modules.Add(smartDigestion);

                SmartEnergy smartEnergy = new();
                smartEnergy.EnergyStored = random.NextDouble() * 10;
                modules.Add(smartEnergy);

                SmartMovement2D smartMovement = new();
                smartMovement.Speed = random.NextDouble() * 1 + 1;
                modules.Add(smartMovement);

                BasicBrain brain = new BasicBrain();
                modules.Add(brain);

                actor.AddModule(modules);
                world.Add(actor);
            }

            world.StepDone += Tick;
            world.ActorKilled += (Actor actor) =>
            {
                Console.WriteLine("Actor died! " + world.Actors.Count + " left");

                if (world.Actors.Count == 0)
                {
                    world.Stop();
                    Console.WriteLine("All actors died, stopped world");
                }
            };

            world.Start();

            while (world.IsRunning)
            {
                Thread.Sleep(1000);
            }
        }

        private static void Tick()
        {
            Console.WriteLine($"Step number {world.CurrentStep}, there are {world.Actors.Count} actors left.");
        }
    }
}