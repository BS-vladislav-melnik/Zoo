using System;
using System.IO;
using System.IO.Pipes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Core;
using MenuUI.Infrastructure;
using MenuUI.UI;
namespace MenuUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategy = new DefaultStateChanger();
            var factory=new AnimalsFactory();
            var repository = new ListRepository(factory);
            var service = new ZooService(repository, strategy);
            var ui = new MainUI(service);
            using (var stream = new NamedPipeClientStream(".", "ZooPipe", PipeDirection.Out, PipeOptions.None))
            {
                var client = new PipeClient(stream);
                ui.Message += client.OnNewMessage;
                ui.Menu();
            }
            
        }
    }
}
