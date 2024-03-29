using System.Runtime.Serialization;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// A World that will run until stopped.
    /// </summary>
    [Serializable]
    public class IndefiniteWorld : World
    {
        private readonly System.Timers.Timer clock;
        private readonly object _timerLock = new();
        private readonly long _millisecondInterval;

        /// <summary>
        /// Indicator of whether the world is running or not.
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
        }
        private bool _isRunning;


        /// <summary>
        /// Creates an instance of the IndefiniteWorld class.
        /// </summary>
        /// <param name="millis">The amount of milliseconds between each step.</param>
        public IndefiniteWorld(long millis) : base()
        {
            _millisecondInterval = millis;
            clock = new System.Timers.Timer(_millisecondInterval);
            clock.Elapsed += Tick;
            clock.AutoReset = false;
        }

        /// <summary>
        /// The method that is called when the internal timer ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object? sender, System.Timers.ElapsedEventArgs e)
        {
            lock (_timerLock)
            {
                if (IsRunning)
                {
                    clock.Enabled = true;
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
            _isRunning = true;
        }

        /// <summary>
        /// Stop the internal timer.
        /// </summary>
        public override void Stop()
        {
            clock.Enabled = false;
            _isRunning = false;
        }

        protected IndefiniteWorld(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _millisecondInterval = GetValue<long>(info, nameof(_millisecondInterval));
            
            clock = new System.Timers.Timer(_millisecondInterval);
            clock.Elapsed += Tick; ;
            clock.AutoReset = false;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(_millisecondInterval), _millisecondInterval);
        }
    }
}