using FosterScript.Core.Worlds;
using System.Numerics;
using System.Runtime.Serialization;

namespace FosterScript.Core.Agents
{
    /// <summary>
    /// Hard-coded AI
    /// </summary>
    [Serializable]
    public class Actor : ISerializable
    {
        /// <summary>
        /// List of "parts" that alter or add to the Actors features.
        /// </summary>
        /// <value></value>
        private List<Module> Modules { get; set; }

        /// <summary>
        /// Check if modules are validated.
        /// </summary>
        private bool AreModulesValidated
        {
            get
            {
                if (_areModulesValidated) { return true; }

                foreach (Module module in Modules)
                {
                    if (!module.CheckDependencies(Modules))
                    {
                        return false;
                    }
                }

                _areModulesValidated = true;
                return _areModulesValidated;
            }
            set
            {
                _areModulesValidated = value;
            }
        }
        private bool _areModulesValidated = false;

        /// <summary>
        /// Current priority number for the Actor. Higher means it gets activated before others.
        /// </summary>
        public int Initiative { get; }

        private readonly World _world;

        public Actor(World world)
        {
            Modules = new List<Module>();
            _world = world;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Actor"/> class with deserialized data.
        /// </summary>
        /// <param name="info">The stream of serialized data.</param>
        /// <param name="context">The current deserialization context.</param>
        protected Actor(SerializationInfo info, StreamingContext context)
        {
            Modules = (List<Module>)info.GetValue(nameof(Modules), typeof(List<Module>));
            _world = (World)info.GetValue(nameof(_world), typeof(World));
        }

        /// <summary>
        /// Populates a SerializationInfo instance with the data required to serialize the Actor.
        /// </summary>
        /// <param name="info">The stream of serialized data.</param>
        /// <param name="context">The current serialization context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Modules), Modules);
            info.AddValue(nameof(_world), _world);
        }

        /// <summary>
        /// Performs any necessary calculations for the Actor in preparation for taking action.
        /// </summary>
        /// <param name="interactibles">List of other Actors the current Actor can interact with.</param>
        public virtual void Think(List<Actor> interactibles)
        {
            if (AreModulesValidated)
            {
                foreach (Module module in Modules)
                {
                    module.Think();
                }
            }
        }

        /// <summary>
        /// Performs any actions for the Actor based on the results of the Think() method.
        /// </summary>
        /// <param name="interactibles">List of other Actors the current Actor can interact with.</param>
        public virtual void Act(List<Actor> interactibles)
        {
            if (AreModulesValidated)
            {
                foreach (Module module in Modules)
                {
                    module.Act();
                }
            }
        }

        /// <summary>
        /// Removes actor from the world.
        /// </summary>
        public void Kill()
        {
            // Queue this actor to be removed
            _world.Remove(this);
        }

        /// <summary>
        /// Move the actor by a vector.
        /// </summary>
        /// <param name="v"></param>
        public void Move(Vector3 v)
        {
            _world.Move(this, v);
        }

        /// <summary>
        /// Add a module to the actor.
        /// </summary>
        /// <param name="module">Module to be added.</param>
        public void AddModule(Module module)
        {
            Modules.Add(module);
            module.Body = this;
            AreModulesValidated = false;
            module.Initialize();
        }

        /// <summary>
        /// Adds a collection of modules to the actor.
        /// </summary>
        /// <param name="moduleList">The collection of modules to add.</param>
        public void AddModule(ICollection<Module> moduleList)
        {
            foreach (Module module in moduleList)
            {
                Modules.Add(module);
                module.Body = this;
            }
            AreModulesValidated = false;

            if (AreModulesValidated)
            {
                foreach (Module module in moduleList)
                    module.Initialize();
            }
        }
    }
}
