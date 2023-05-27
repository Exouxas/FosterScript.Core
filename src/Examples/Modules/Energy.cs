using FosterScript.Core.Agents;

namespace FosterScript.Examples.Modules
{
    internal class Energy : Module
    {
        #region "Inherited Properties"
        public override string Name => "Energy";
        public override int[] Version => new int[] { 1, 0, 0 };
        #endregion

        #region "Properties"
        public double EnergyStored 
        {
            get
            {
                return _energyStored;
            }
            set
            {
                if(value <= 0)
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
