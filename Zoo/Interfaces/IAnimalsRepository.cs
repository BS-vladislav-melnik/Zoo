using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Interfaces
{
    public interface IAnimalsRepository
    {
        IList<IAnimal> Animals { get; }
        event Action AllDead;
        void Feed(string name);
        void Heal(string name);
        void FastingProcess();
        void Add(string name, string type);
        bool Remove(string name);
    }
}
