using FosterScript.Core.Agents;

namespace FosterScript.Examples.Modules
{
    public class Energy : Module
    {
        #region "Inherited Properties"
        public override string Name => "Energy";
        public override int[] Version => new int[] { 1, 0, 0 };
        #endregion

        #region "Properties"
        /// <summary>
        /// The amount of energy stored.
        /// </summary>
        public double EnergyStored
        {
            get
            {
                return _energyStored;
            }
            set
            {
                if (value <= 0)
                {
                    Body?.Kill();
                }
                _energyStored = value;
            }
        }
        private double _energyStored;
        #endregion

        public Energy() : base()
        {

        }

        public override void Initialize()
        {
            // Nothing to initialize
        }

        public override void Think()
        {
            // Module only used as value storage
        }

        public override void Act()
        {
            // Module only used as value storage
        }
    }
}
