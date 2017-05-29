using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooLib.Interfaces;
using ZooLib.Enums;
using ZooLib.Infrastructure;
using ZooLib.Exceptions;
namespace ZooLib.Core
{
   public class ZooService
    {
        public event Action AllDead;
        public event StateChanged StateChanged;
        private IAnimalsRepository _repository;
        private IStateChanger _strategy;
        private IAnimalsFactory _factory;
        public ZooService(IAnimalsRepository repository, IStateChanger strategy, IAnimalsFactory factory)
        {
            _repository = repository;
            _strategy = strategy;
            _factory = factory;
        }
        public void Add(string name, string typename)
        {
            if (_repository.Get(name) == null)
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
                _repository.Add(newAnimal);


            }
        }
        public bool Remove(string name)
        {
            var animal = _repository.Get(name);
            if (animal == null || animal.State != Enums.AnimalState.Dead)
                return false;
            else
            {
                 return _repository.Remove(animal);
            }
        }
        public void Feed(string name)
        {
            var element = _repository.Get(name);
            if (element.State== AnimalState.Dead)
            {
                throw new AnimalDeadException("Too late to feed");
            }
            if ((int)element.State < 3) element.State = AnimalState.Full;
            StateChanged?.Invoke(element.State, element.Health, element.Name);
        }
        public void Heal(string name)
        {
            var element = _repository.Get(name);
            if (element.Health == 0)
                throw new AnimalDeadException("Too late to heal");
            element.Health++;
            StateChanged?.Invoke(element.State, element.Health, element.Name);
        }
        public void FastingProcess()
        {

            Random randomizer = new Random(); 
            var isAllDead = false;
            while (!isAllDead)
            {
                Thread.Sleep(5000);
                var nonDeadList = _repository.GetAll().Where(x => x.State != AnimalState.Dead);
                if (nonDeadList.Count() != 0)
                {
                    var element = nonDeadList.ElementAt(randomizer.Next(nonDeadList.Count()));
                    _strategy.FastingProcess(element);
                    StateChanged?.Invoke(element.State, element.Health, element.Name);
                }
                isAllDead = (_repository.GetAll().Where(x => x.State == AnimalState.Dead).Count() == _repository.GetAll().Count()) &&
                             _repository.GetAll().Count() > 0;
            }
            AllDead?.Invoke();
        }

    }
}
