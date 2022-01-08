using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    public interface ICanAugment
    {
        abstract List<ICanSupplement> Inputs { get; }
    }
}
