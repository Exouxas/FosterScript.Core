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
        public double StoredMeat { get; set; }
        public double StoredPlant { get; set; }
        public double DigestionRate { get; set; }
        #endregion

        public Digestion() : base()
        {
            Dependencies.Add("Energy", new int[] { 1, 0, 0 });
        }

        public override void Initialize()
        {

        }

        public override void Think()
        {

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
