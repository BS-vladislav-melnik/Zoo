using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.UI;
using Zoo.Core;
namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategy =new DefaultStrategy();
            var factory = new ZooFactory(strategy);
            var repository = new ZooRepository(factory);
            var menu=new MainUI(repository);
            menu.Menu();
        }
    }
}
