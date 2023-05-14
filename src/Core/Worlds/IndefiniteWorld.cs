using FosterScript.Core.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// A World that will run until stopped.
    /// </summary>
    [Serializable]
    public class IndefiniteWorld : World, ISerializable
    {
        private System.Timers.Timer clock;
        private readonly object _timerLock = new object();
        public bool IsRunning => clock.Enabled;

        private long _millisecondInterval;

        /// <summary>
        /// Creates an instance of the IndefiniteWorld class.
        /// </summary>
        /// <param name="millis">The amount of milliseconds between each step.</param>
        public IndefiniteWorld(long millis) : base()
        {
            _millisecondInterval = millis;
            clock = new System.Timers.Timer(_millisecondInterval);
            clock.Elapsed += Tick; ;
            clock.AutoReset = false;
        }

        private void Tick(object? sender, System.Timers.ElapsedEventArgs e)
        {
            lock(_timerLock)
            {
                if (IsRunning)
                {
                    clock.Start();
                    Step();
                }
            }
        }

        /// <summary>
        /// Start the internal timer. Will run until you call the Stop() method.
        /// </summary>
        public override void Start()
        {
            clock.Enabled = true;
        }

        /// <summary>
        /// Stop the internal timer.
        /// </summary>
        public override void Stop()
        {
            clock.Enabled = false;
        }

        protected IndefiniteWorld(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _millisecondInterval = info.GetInt64(nameof(_millisecondInterval));
            clock = new System.Timers.Timer(_millisecondInterval);
            clock.Elapsed += Tick; ;
            clock.AutoReset = false;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(_millisecondInterval), _millisecondInterval);
        }
    }
}