using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Enums;
namespace Zoo.Interfaces
{
   public interface IStrategy
    {
       void FastingProcess(ref int health,ref AnimalState state);
       void Heal(ref int health, int maxHealth);
       void Feed(ref AnimalState state);
    }
}
