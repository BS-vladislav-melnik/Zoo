using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Interfaces;
using Zoo.Enums;
namespace Zoo.Core
{
   public abstract class Animal:IAnimal
    {
        #region Fields
        private string _name;
        protected int _health;
        protected int _maxHealth;
        protected AnimalState _state;
        private IStrategy _strategy;
        private object _sync;
        #endregion
        #region Props
        public string Name {
            get {
                return _name;
            }
        }
        public int Health {
            get {
                return _health;
            }
        }
        public AnimalState State {
            get {
                return _state;
            }
        }
        #endregion
        public Animal(string name, int maxHealth, IStrategy strategy)
        {   if (name == string.Empty)
                throw new ArgumentException("Name cannot be null","name");
            _name = name;
            _state = AnimalState.Full;
            _health= _maxHealth = maxHealth;
            _strategy = strategy;
            _sync = new object();
        }
        public void FastingProcess()
        {
            lock (_sync) { 
            _strategy.FastingProcess(ref _health,ref _state);
            }
        }
        public void Heal()
        {
            lock (_sync)
            {
                _strategy.Heal(ref _health, _maxHealth);
            }
        }
        public void Feed()
        {
            lock (_sync)
            {
                _strategy.Feed(ref _state);
            }
        }

    }
}
