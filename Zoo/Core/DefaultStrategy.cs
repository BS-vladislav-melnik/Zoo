using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Interfaces;
using Zoo.Enums;
using Zoo.Core.Exeptions;
namespace Zoo.Core
{
   public class DefaultStrategy:IStrategy
    {
       public void FastingProcess(ref int health, ref AnimalState state)
        {
            
                switch (state)
                {
                    case AnimalState.Full:
                        state = AnimalState.Hungry;
                        break;
                    case AnimalState.Hungry:
                        state = AnimalState.Sick;
                        break;
                    case AnimalState.Sick:
                        health--;
                        if (health == 0) 
                        {
                            state = AnimalState.Dead;
                        }
                        break;
                    case AnimalState.Dead:
                            throw new AnimalDeadExeption("Animal already dead");
                    default:
                        break;
                }
        }
       public void Heal(ref int health, int maxHealth)
        {
            if (health == 0)
                throw new AnimalDeadExeption("Too late to heal");
            if (maxHealth - health > 0)
            {
                health++;
            }
        }
       public void Feed(ref AnimalState state)
        {
            if (state == AnimalState.Dead)
            {
                throw new AnimalDeadExeption("Too late to feed");
            }
            if ((int)state < 3) state++;
        }
    }
}
