using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Exceptions
{
    [System.Serializable]
    public class AnimalDeadException : Exception
    {
        public AnimalDeadException() { }
        public AnimalDeadException(string message) : base(message) { }
        public AnimalDeadException(string message, Exception inner) : base(message, inner) { }
        protected AnimalDeadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    

    
}
