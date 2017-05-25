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
        private IStrategy _strategy;
        ZooFactory(IStrategy strategy)
        {
            _strategy = strategy;
        }
        public IAnimal CreateBear(string name)
        {
            return new Bear(name, _strategy);
        }
        public IAnimal CreateElephant(string name)
        {
            return new Elephant(name, _strategy);
        }
        public IAnimal CreateFox(string name)
        {
            return new Fox(name, _strategy);
        }
        public IAnimal CreateLion(string name)
        {
            return new Lion(name, _strategy);
        }
        public IAnimal CreateTiger(string name)
        {
            return new Tiger(name, _strategy);
        }
        public IAnimal CreateWolf(string name)
        {
            return new Wolf(name, _strategy);
        }
    }
}
