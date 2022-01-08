using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib
{
    public abstract class Neuron
    {
        public string Name
        {
            get { return name; }
        }
        protected string name;

        public string Description
        {
            get { return description; }
        }
        protected string description;



        public Neuron()
        {
            name = "";
            description = "";
        }
    }
}
