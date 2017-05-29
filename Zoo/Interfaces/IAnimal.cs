using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Enums;
namespace ZooLib.Interfaces
{
   public interface IAnimal
    {
        string Name { get; }
        int Health { get; set; }
        AnimalState State { get; set; }
    }
}
