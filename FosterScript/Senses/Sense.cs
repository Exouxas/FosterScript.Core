using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FosterScriptLib.Neurons;

namespace FosterScriptLib.Senses
{
    public abstract class Sense : Neuron
    {
        public abstract Creature Parent { get; }
    }
}
