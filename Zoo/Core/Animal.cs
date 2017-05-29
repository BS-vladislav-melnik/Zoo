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
        private string _name;
        protected int _health;
        protected int _maxHealth;
        protected AnimalState _state;
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
        public Animal(string name, int maxHealth)
        {
            if (name == string.Empty)
                throw new ArgumentException("Name cannot be null","name");
            _name = name;
            _state = AnimalState.Full;
            _health= _maxHealth = maxHealth;
            _sync = new object();
        }


    }
}
