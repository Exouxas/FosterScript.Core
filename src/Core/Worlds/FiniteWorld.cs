using System.Runtime.Serialization;

namespace FosterScript.Core.Worlds
{
    /// <summary>
    /// A World that will run a set amount of times.
    /// </summary>
    [Serializable]
    public class FiniteWorld : World, ISerializable
    {
        private readonly long _steps;
        private bool _isRunning = false;

        /// <summary>
        /// Creates an instance of the FiniteWorld class.
        /// </summary>
        /// <param name="steps">The amount of steps it will run.</param>
        public FiniteWorld(long steps) : base()
        {
            _steps = steps;
        }

        /// <summary>
        /// Start running the steps. Will run until you either call the Stop() method or it completes the set amount of steps.
        /// </summary>
        public override void Start()
        {
            _isRunning = true;
            while (_isRunning)
            {
                Step();
                if (CurrentStep == _steps)
                {
                    _isRunning = false;
                }
            }
        }

        /// <summary>
        /// Stop.
        /// </summary>
        public override void Stop()
        {
            _isRunning = false;
        }

        protected FiniteWorld(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _steps = info.GetInt64(nameof(_steps));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(_steps), _steps);
        }
    }
}