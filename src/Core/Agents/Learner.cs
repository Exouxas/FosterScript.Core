using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FosterScript.Agents
{
    /// <summary>
    /// An actor with an evolving brain.
    /// </summary>
    public class Learner : Actor
    {
        public Learner(float x, float y) :base(x, y)
        {

        }

        public Learner(float x, float y, string geneticDirectory): base(x, y, geneticDirectory)
        {
            
        }

        public override void Act()
        {
            throw new NotImplementedException();
        }

        public override void Think()
        {
            throw new NotImplementedException();
        }
    }
}