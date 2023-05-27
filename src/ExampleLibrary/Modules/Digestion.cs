using FosterScript.Core.Agents;

namespace FosterScript.Examples.Modules
{
    public class Digestion : Module
    {
        #region "Inherited Properties"
        public override string Name => "Digestion";
        public override int[] Version => new int[] { 1, 0, 0 };
        #endregion

        #region "Properties"
        /// <summary>
        /// The amount of stored meat resources.
        /// </summary>
        public double StoredMeat { get; set; }

        /// <summary>
        /// The amount of stored plant resources.
        /// </summary>
        public double StoredPlant { get; set; }

        /// <summary>
        /// The rate at which food is digested.
        /// </summary>
        public double DigestionRate { get; set; }
        #endregion

        public Digestion() : base()
        {
            Dependencies.Add("Energy", new int[] { 1, 0, 0 });
        }

        public override void Initialize()
        {
            // Nothing to initialize
        }

        public override void Think()
        {
            // Actor gets a permanent digestion rate, so there's nothing to think about
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
