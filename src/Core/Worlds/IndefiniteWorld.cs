using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// A World that will run until stopped.
    /// </summary>
    public class IndefiniteWorld : World
    {
        private System.Timers.Timer clock;
        public bool IsRunning => clock.Enabled;

        /// <summary>
        /// Creates an instance of the IndefiniteWorld class.
        /// </summary>
        /// <param name="millis">The amount of milliseconds between each step.</param>
        public IndefiniteWorld(long millis) : base()
        {
            clock = new System.Timers.Timer(millis);
            clock.Elapsed += Tick; ;
            clock.AutoReset = true;
        }

        private void Tick(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Step();
        }

        /// <summary>
        /// Start the internal timer. Will run until you call the Stop() method.
        /// </summary>
        public override void Start(){
            clock.Enabled = true;
        }

        /// <summary>
        /// Stop the internal timer.
        /// </summary>
        public override void Stop(){
            clock.Enabled = false;
        }
    }
}
