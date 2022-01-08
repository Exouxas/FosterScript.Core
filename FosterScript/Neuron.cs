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


        public double Output
        {
            get
            {
                savedOutput = calculateOutput();
                return savedOutput;
            }
        }
        protected double savedOutput;



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


        protected abstract double calculateOutput();
    }
}
