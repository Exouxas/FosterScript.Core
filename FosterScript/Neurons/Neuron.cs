using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Neurons
{
    public abstract class Neuron
    {
        public string Name
        {
            get { return name; }
        }
        internal string name;

        public string Description
        {
            get { return description; }
        }
        internal string description;


        public abstract double Output { get; }



        public List<Neuron> Inputs 
        { 
            get { return inputs; }
        }
        internal List<Neuron> inputs;

        public Neuron()
        {
            inputs = new List<Neuron>();
        }



        public void AddInput(Neuron n)
        {
            inputs.Add(n);
        }
    }
}
