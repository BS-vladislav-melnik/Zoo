using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLog.Infrastructure;
namespace MessageLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new PipeClient();
            client.Start();
        }
    }
}
