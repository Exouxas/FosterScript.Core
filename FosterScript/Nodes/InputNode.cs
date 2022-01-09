using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    public abstract class InputNode : Neuron, ICanSupplement
    {
        public double Output 
        {
            get
            {
                if (!HasCalculated)
                {
                    storedOutput = GetOutput();
                    HasCalculated = true;
                }
                return storedOutput;
            } 
        }
        private double storedOutput;

        public bool HasCalculated { get; set; }

        protected abstract double GetOutput();

        protected InputNode(string name, string description) : base(name, description)
        {

        }
    }
}
