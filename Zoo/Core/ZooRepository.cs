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
   public class ZooRepository:IAnimalsRepository
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
            
            Random randomizer = new Random(); ;
            var isAllDead=false;
            while (!isAllDead)
            {
                Thread.Sleep(5000); 
                var nonDeadList = _animals.Where(x => x.State != AnimalState.Dead);
                if (nonDeadList.Count() != 0)
                {

                    nonDeadList.ElementAt(randomizer.Next(nonDeadList.Count())).FastingProcess();
                }
                isAllDead = (_animals.Where(x => x.State == AnimalState.Dead).Count() == _animals.Count()) &&
                             _animals.Count() > 0;
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
                    case "elephant":
                        newAnimal=_factory.CreateElephant(name);
                        break;
                    case "fox":
                        newAnimal=_factory.CreateFox(name);
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
