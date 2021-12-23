using FosterScriptLib.Organs;

namespace FosterScriptLib
{
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
    }
}