using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZooLib.Interfaces;
using ZooLib.Enums;
using ZooLib.Infrastructure;
namespace ZooLib.Core
{
   
   public class ListRepository:IAnimalsRepository
    {
        private readonly List<IAnimal> _animals;
        private readonly IAnimalsFactory _factory;
        public ListRepository(IAnimalsFactory factory)
        {
            _animals = new List<IAnimal>();
            _factory = factory;
        }
        public IList<IAnimal> GetAll()
        {
            return new ReadOnlyCollection<IAnimal>(_animals);
        }
       
        public IAnimal Get(string name)
        {
            return _animals.Find(x => x.Name == name);
        }
        public void Add( string name, string typename)
        {
            if (Get(name) == null)
            {
                IAnimal newAnimal;
                switch (typename.ToLower())
                {
                    case "bear":
                        newAnimal = _factory.CreateBear(name);
                        break;
                    case "elephant":
                        newAnimal = _factory.CreateElephant(name);
                        break;
                    case "fox":
                        newAnimal = _factory.CreateFox(name);
                        break;
                    case "lion":
                        newAnimal = _factory.CreateLion(name);
                        break;
                    case "tiger":
                        newAnimal = _factory.CreateTiger(name);
                        break;
                    case "wolf":
                        newAnimal = _factory.CreateWolf(name);
                        break;
                    default:
                        throw new ArgumentException("Invalid type name");
                }
                _animals.Add(newAnimal);
            }
        }
        public bool Remove(IAnimal animal)
        {
            return _animals.Remove(animal);
        }
        public bool RemoveByName(string name)
        {
            var animal = Get(name);
            if (animal == null || animal.State != Enums.AnimalState.Dead)
                return false;
            return Remove(animal);
        }
    }
}
