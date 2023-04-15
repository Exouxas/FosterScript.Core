﻿using FosterScript.Core.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Examples.Modules
{
    internal class RandomMovement2D : Module
    {
        #region "Inherited Properties"
        public override string Name => "RandomMovement2D";
        public override int[] Version => new int[] { 1, 0, 0 };
        #endregion

        #region "Properties"
        public double Speed { get; set; }
        #endregion
        public RandomMovement2D() : base()
        {
            Dependencies.Add("Energy", new int[] { 1, 0, 0 });
        }
        public override void Think()
        {
            
        }
        public override void Act()
        {
            // Move randomly
            Random random = new Random();
            float x = (float)((random.NextDouble() * 2 - 1) * Speed);
            float y = (float)((random.NextDouble() * 2 - 1) * Speed);
            double distance = Math.Sqrt(x * x + y * y);

            // Exponentially more exhausting to move faster
            ((Energy)DependencyReferences["Energy"]).EnergyStored -= distance * Speed * Speed;
            Body?.Move(new Vector3(x, y, 0));
        }
    }
}
