using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using FosterScript.Core.Worlds;

namespace FosterScript.Core.Agents
{
    /// <summary>
    /// An actor with an evolving brain.
    /// </summary>
    public class Learner : Actor
    {
        public Learner(World world) :base(world)
        {

        }

        public override void Act(List<Actor> interactibles)
        {
            throw new NotImplementedException();
        }

        public override void Think(List<Actor> interactibles)
        {
            throw new NotImplementedException();
        }
    }
}