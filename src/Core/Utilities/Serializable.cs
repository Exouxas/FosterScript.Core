using System.Runtime.Serialization;

namespace FosterScript.Core.Utilities
{
    public abstract class Serializable : ISerializable
    {
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        protected static T GetValue<T>(SerializationInfo info, string name)
        {
            return (T)(info.GetValue(name, typeof(T)) ?? throw new SerializationException());
        }
    }
}
