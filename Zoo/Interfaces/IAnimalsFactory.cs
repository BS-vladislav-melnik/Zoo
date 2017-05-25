using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Interfaces
{
    public interface IAnimalsFactory
    {
        IAnimal CreateBear(string name);
        IAnimal CreateElephant(string name);
        IAnimal CreateFox(string name);
        IAnimal CreateLion(string name);
        IAnimal CreateTiger(string name);
        IAnimal CreateWolf(string name);
    }
}
