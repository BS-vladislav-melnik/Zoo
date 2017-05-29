using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Interfaces;
using ZooLib.Enums;
namespace ZooLib.Core
{
   public abstract class Animal:IAnimal
    {
        #region Fields
        private readonly string _name;
        private readonly int _maxHealth;
        private int _health;       
        private AnimalState _state;
        #endregion
        #region Props
        public string Name => _name;
        public int Health {
            get {
                return _health;
            }
            set {
                if (value >= 0 && value <= _maxHealth)
                    _health = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public AnimalState State {
            get {
                return _state;
            }
            set {
                _state = value;
            }
        }
        #endregion

        protected Animal(string name, int maxHealth)
        {
            if (name == string.Empty)
                throw new ArgumentException("Name cannot be null",nameof(name));
            _name = name;
            _state = AnimalState.Full;
            _health= _maxHealth = maxHealth;
        }


    }
}
