using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Enums;
namespace Zoo.Interfaces
{
   public interface IAnimal
    {
        string Name { get; }
        int Health { get; }
        AnimalState State { get;  }
        
    }
}
