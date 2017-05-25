using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Zoo.Interfaces;
using Zoo.Enums;
namespace Zoo.Core
{
    class ZooRepository:IAnimalsRepository
    {
        private List<IAnimal> _animals;
        private IAnimalsFactory _factory;
        public event Action AllDead;
        public IList<IAnimal> Animals {

            get {
                return new ReadOnlyCollection<IAnimal>(_animals);
            }
        }

        public ZooRepository(IAnimalsFactory factory)
        {
            _animals = new List<IAnimal>();
            _factory = factory;
        }
        public void Feed(string name)
        {
             FindByName(name).Feed();            
        }
        public void Heal(string name)
        {
             FindByName(name).Heal();   
        }
        public void FastingProcess()
        {
            var randomizer = new Random();
            var isAllDead = _animals.Where(x => x.State == AnimalState.Dead).Count() == _animals.Count();
            while (!isAllDead)
            {
                if (_animals.Count != 0)
                {
                    Thread.Sleep(5000);
                    _animals[randomizer.Next(_animals.Count - 1)].FastingProcess();
                }
            }
            AllDead?.Invoke();
        }
        public void Add(string name, string typename)
        {
            if (FindByName(name) == null)
            {
                IAnimal newAnimal;
                switch (typename.ToLower())   
                {
                    case "bear":
                        newAnimal=_factory.CreateBear(name);
                        break;
                    case "Elephant":
                        newAnimal=_factory.CreateElephant(name);
                        break;
                    case "Fox":
                        newAnimal=_factory.CreateFox(name);
                        break;
                    case "Lion":
                        newAnimal = _factory.CreateLion(name);
                        break;
                    case "Tiger":
                        newAnimal = _factory.CreateTiger(name);
                        break;
                    case "Wolf":
                        newAnimal = _factory.CreateWolf(name);
                        break;
                    default:
                        throw new ArgumentException("Invalid type name");
                }             
                _animals.Add(newAnimal);

               
            }
        }
        public bool Remove(string name)
        {
            var animal = FindByName(name);
            
            if (animal == null||animal.State != Enums.AnimalState.Dead)
                return false;
            else
            {
                _animals.Remove(animal);
                return true;
            }
        }
        private IAnimal FindByName(string name)
        {
            return _animals.Find(x => x.Name == name);
        }
    }
}
