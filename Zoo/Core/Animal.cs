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
        public Animal(string name, int maxHealth)
        {   if (name == string.Empty)
                throw new ArgumentException("Name cannot be null","name");
            _name = name;
            _state = AnimalState.Full;
            _health= _maxHealth = maxHealth;
        }

       
    }
}
