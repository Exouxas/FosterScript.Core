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
        protected string name;

        public string Description
        {
            get { return description; }
        }
        protected string description;


        public abstract double Output { get; }



        public List<Neuron> Inputs 
        { 
            get { return inputs; }
        }
        protected List<Neuron> inputs;

        public Neuron()
        {
            inputs = new List<Neuron>();
            name = "";
            description = "";
        }



        public void AddInput(Neuron n)
        {
            inputs.Add(n);
        }
    }
}
