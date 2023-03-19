using FosterScript.Core;
using FosterScript.Core.Worlds;

namespace FosterScript.Examples
{
    public static class Application
    {
        public static void Main(string[] args){
            Console.WriteLine("Hello World");
            IndefiniteWorld world = new IndefiniteWorld(500);
            world.StepDone += Tick;
            world.Start();
        }

        private static void Tick(){
            Console.WriteLine("World did a thing");
        }
    }
}