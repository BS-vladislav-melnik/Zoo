using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Interfaces;
using Zoo.Enums;
namespace Zoo.Core
{
    class Animal:IAnimal
    {
       private AnimalState _state;
       private int _health;
       public AnimalState State { get; }
       public int Health { get; }

    }
}
