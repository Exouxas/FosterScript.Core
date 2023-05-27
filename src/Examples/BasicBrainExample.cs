using FosterScript.Core.Worlds;
using FosterScript.Core.Agents;
using FosterScript.Examples.Modules.SmartModules;

namespace FosterScript.Examples
{
    public static class BasicBrainExample
    {
        static IndefiniteWorld world = new(500);
        public static void Main(string[] args)
        {
            Console.WriteLine("Indefinite World Example");

            Random random = new();

            Console.WriteLine("Creating actors");
            for(int i = 0; i < 3; i++)
            {
                Actor actor = new(world);
                List<Module> modules = new List<Module>();

                SmartDigestion d = new();
                d.DigestionRate = random.NextDouble() * 2;
                d.StoredMeat = random.NextDouble() * 5;
                d.StoredPlant = random.NextDouble() * 5;
                modules.Add(d);

                SmartEnergy e = new();
                e.EnergyStored = random.NextDouble() * 10;
                modules.Add(e);

                SmartMovement2D mov = new();
                mov.Speed = random.NextDouble() * 1 + 1;
                modules.Add(mov);

                BasicBrain brain = new BasicBrain();
                modules.Add(brain);

                actor.AddModule(modules);
                world.Add(actor);
            }

            world.StepDone += Tick;
            world.ActorKilled += (Actor actor) =>
            {
                Console.WriteLine("Actor died! " + world.Actors.Count + " left");

                if(world.Actors.Count == 0)
                {
                    world.Stop();
                    Console.WriteLine("All actors died, stopped world");
                }
            };

            world.Start();

            while(world.IsRunning) { }
        }

        private static void Tick()
        {
            World w = world;
            Console.WriteLine($"Step number {world.CurrentStep}, there are {world.Actors.Count} actors left.");
        }
    }
}