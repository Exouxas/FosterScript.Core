using System.Numerics;

namespace FosterScriptLib
{
    /// <summary>
    /// Creature that will be evolving
    /// </summary>
    public class Creature
    {
        /*
         * Idea is being revised. The new way of making this will be more modular.
         * 
         * 
         * Each "module" will attempt to be self-sufficient. 
         * 
         * A module can be dependent on another module, although it will not crash the software if the dependency is missing.
         * 
         * This creature will only have base functionality. (like position, size, and colour)
         */

        public List<Organ> Organs { get; set; }

        public Vector2 Position { get; set; }

        public double Radius { get; set; }

        public System.Drawing.Color Color { get; set; }

        public string GeneticDirectory 
        {
            get
            {
                return GeneticDirectory;
            }
            set 
            { 
                // TODO: Code for reading what organs the creature can have. (Script folder)
            } 
        }

        public Creature(float x, float y)
        {
            Position = new Vector2(x, y);
            Organs = new List<Organ>();
        }

        public Creature(float x, float y, string geneticDirectory): this(x, y)
        {
            GeneticDirectory = geneticDirectory;
        }
    }
}