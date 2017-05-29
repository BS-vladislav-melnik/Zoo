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
using ZooLib.Core.Animals;
namespace ZooLib.Core
{
    public class ZooService
    {
        public event Action AllDead;
        public event StateChanged StateChanged;
        private readonly IAnimalsRepository _repository;
        private readonly IStateChanger _strategy;
        public IAnimalsRepository Repository => _repository;

        public ZooService(IAnimalsRepository repository, IStateChanger strategy)
        {
            _repository = repository;
            _strategy = strategy;
        }

        public void Feed(string name)
        {
            var element = _repository.Get(name);
            if (element.State == AnimalState.Dead)
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

            var randomizer = new Random();
            var isAllDead = false;
            while (!isAllDead)
            {
                Thread.Sleep(5000);
                var nonDeadList = _repository.GetAll().Where(x => x.State != AnimalState.Dead).ToList();
                if (nonDeadList.Count() != 0)
                {
                    var element = nonDeadList.ElementAt(randomizer.Next(nonDeadList.Count()));
                    _strategy.FastingProcess(element);
                    StateChanged?.Invoke(element.State, element.Health, element.Name);
                }
                isAllDead = (_repository.GetAll().Count(x => x.State == AnimalState.Dead) == _repository.GetAll().Count()) &&
                             _repository.GetAll().Any();
            }
            AllDead?.Invoke();
        }
    
    }
}
