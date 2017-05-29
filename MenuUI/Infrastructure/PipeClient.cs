using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;
namespace MenuUI.Infrastructure
{
   public class PipeClient
    {
        private readonly NamedPipeClientStream _stream;
        public PipeClient(NamedPipeClientStream stream)
        {
            _stream = stream;
            _stream.Connect();
        }
        public void OnNewMessage(string message, System.ConsoleColor color)
        {
            var msg = new Tuple<string, ConsoleColor>(message,color);
            var formatter = new BinaryFormatter();          
            formatter.Serialize(_stream, msg);
        }
    }
}
