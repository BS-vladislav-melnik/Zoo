using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Enums;
namespace ZooLib.Infrastructure
{
    public delegate void StateChanged(AnimalState state, int health,string name);
}
