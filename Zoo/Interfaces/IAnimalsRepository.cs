using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Infrastructure;
namespace ZooLib.Interfaces
{
    public interface IAnimalsRepository
    {
        IList<IAnimal> GetAll();
        void Add(IAnimal animal);
        bool Remove(IAnimal animal);
        IAnimal Get(string name);
    }
}
