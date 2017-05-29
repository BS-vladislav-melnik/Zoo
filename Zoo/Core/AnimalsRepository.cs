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
   
   public class AnimalsRepository:IAnimalsRepository
    {
        private List<IAnimal> _animals;

        public AnimalsRepository()
        {
            _animals = new List<IAnimal>();
        }
        public IList<IAnimal> GetAll()
        {
            return new ReadOnlyCollection<IAnimal>(_animals);
        }
        public void Add(IAnimal animal)
        {
                _animals.Add(animal);
        
        }
        public bool Remove(IAnimal animal)
        {
           return  _animals.Remove(animal);            
        }
        public IAnimal Get(string name)
        {
            return _animals.Find(x => x.Name == name);
        }
    }
}
