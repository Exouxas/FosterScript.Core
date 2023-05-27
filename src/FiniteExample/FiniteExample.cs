using FosterScript.Core.Agents;
using FosterScript.Core.Worlds;
using FosterScript.Examples.Modules;

namespace FosterScript.Examples
{
    public static class FiniteExample
    {
        static readonly FiniteWorld world = new(20);

        public static void Main(string[] args)
        {
            Console.WriteLine("Finite World Example");

            Random random = new();

            Console.WriteLine("Creating actors");
            for (int i = 0; i < 3; i++)
            {
                Actor actor = new(world);

                Digestion d = new();
                d.DigestionRate = random.NextDouble() * 2;
                d.StoredMeat = random.NextDouble() * 5;
                d.StoredPlant = random.NextDouble() * 5;
                actor.AddModule(d);

                Energy e = new();
                e.EnergyStored = random.NextDouble() * 10;
                actor.AddModule(e);

                RandomMovement2D mov = new();
                mov.Speed = random.NextDouble() * 1 + 1;
                actor.AddModule(mov);

                world.Add(actor);
            }
            Console.WriteLine($"{world.Actors.Count} actors created");

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

            Console.WriteLine($"Starting world");
            world.Start();
            Console.WriteLine($"World finished");
        }

        private static void Tick()
        {
            Console.WriteLine($"Step number {world.CurrentStep}, there are {world.Actors.Count} actors left.");
        }
    }
}