using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScriptLib.Nodes
{
    public interface ICanSupplement
    {
        public double Output { get; }
        public bool HasCalculated { get; set; }
    }
}
