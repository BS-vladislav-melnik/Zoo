using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Exeptions
{
    [System.Serializable]
    public class AnimalDeadExeption : Exception
    {
        public AnimalDeadExeption() { }
        public AnimalDeadExeption(string message) : base(message) { }
        public AnimalDeadExeption(string message, Exception inner) : base(message, inner) { }
        protected AnimalDeadExeption(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    

    
}
