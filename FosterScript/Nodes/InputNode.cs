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
                return GetOutput();
            } 
        }
        protected abstract double GetOutput();

        protected InputNode(string name, string description) : base(name, description)
        {

        }
    }
}
