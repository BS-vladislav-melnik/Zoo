using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Interfaces;
using Zoo.Core.Animals;
namespace Zoo.Core
{
    //Can be considered as simplified implementation of "Factory method"
    public class ZooFactory: IAnimalsFactory
    {
        public IAnimal CreateBear(string name)
        {
            return new Bear(name);
        }
        public IAnimal CreateElephant(string name)
        {
            return new Elephant(name);
        }
        public IAnimal CreateFox(string name)
        {
            return new Fox(name);
        }
        public IAnimal CreateLion(string name)
        {
            return new Lion(name);
        }
        public IAnimal CreateTiger(string name)
        {
            return new Tiger(name);
        }
        public IAnimal CreateWolf(string name)
        {
            return new Wolf(name);
        }
    }
}
