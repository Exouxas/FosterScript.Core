using FosterScriptLib.Neurons;

namespace FosterScriptLib.Senses
{
    public abstract class Sense : Neuron
    {
        protected abstract ISensor Parent { get; }
    }
}
