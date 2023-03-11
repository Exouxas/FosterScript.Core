using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers.Timer;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// A World that will run until stopped.
    /// </summary>
    public class IndefiniteWorld : World
    {
        // TODO: Add clock cycle
        private Timer clock;

        /// <summary>
        /// Creates an instance of the IndefiniteWorld class.
        /// </summary>
        /// <param name="millis">The amount of milliseconds between each step.</param>
        public IndefiniteWorld(long millis) : base()
        {
            clock = new Timer(millis);
            clock.Elapsed += Tick;
            clock.AutoReset = true;
        }

        private void Tick(Object source, ElapsedEventArgs e)
        {
            Step();
        }

        /// <summary>
        /// Start the internal timer. Will run until you call the Stop() method.
        /// </summary>
        public void Start(){
            clock.Enabled = true;
        }

        /// <summary>
        /// Stop the internal timer.
        /// </summary>
        public void Stop(){
            clock.Enabled = false;
        }
    }
}
