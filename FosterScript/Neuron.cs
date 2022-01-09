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
            get { return _name; }
        }
        protected string _name;

        public string Description
        {
            get { return _description; }
        }
        protected string _description;



        protected Neuron(string name, string description)
        {
            _name = name;
            _description = description;
        }
    }
}
