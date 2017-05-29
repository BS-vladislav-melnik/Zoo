using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
namespace MessageLog.Infrastructure
{
   public class PipeClient
    {
        public void Start()
        {
            using (var server = new NamedPipeServerStream("ZooPipe", PipeDirection.In))
            {
                server.WaitForConnection();
                var formatter = new BinaryFormatter();
                while (server.IsConnected)
                {
                    try
                    {
                        var stream = new BufferedStream(server);
                        
                        var msg = (Tuple<string, ConsoleColor>)formatter.Deserialize(stream);
                        Console.ForegroundColor = msg.Item2;
                        Console.WriteLine(msg.Item1);
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex.Message); 
                    }
                }
            }
        }
    }
}
