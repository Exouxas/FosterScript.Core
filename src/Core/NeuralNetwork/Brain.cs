using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FosterScript.Core.NeuralNetwork
{
    /// <summary>
    /// Stores and calculates nodes.
    /// </summary>
    [Serializable]
    public class Brain : ISerializable
    {
        public Brain()
        {

        }

        protected Brain(SerializationInfo info, StreamingContext context)
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
