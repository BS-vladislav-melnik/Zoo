using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Interfaces;
using ZooLib.Enums;
using ZooLib.Exceptions;
namespace ZooLib.Core
{
   public class DefaultStateChanger:IStateChanger
    {
       public void FastingProcess(IAnimal animal)

        {
            
                switch (animal.State)
                {
                    case AnimalState.Full:
                        animal.State = AnimalState.Hungry;
                        break;
                    case AnimalState.Hungry:
                        animal.State = AnimalState.Sick;
                        break;
                    case AnimalState.Sick:
                         animal.Health--;
                        if (animal.Health == 0) 
                        {
                        animal.State = AnimalState.Dead;
                        }
                        break;
                    case AnimalState.Dead:
                            throw new AnimalDeadException("Animal already dead");
                }
        }
       
    }
}
