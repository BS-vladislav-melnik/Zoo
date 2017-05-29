using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Interfaces;
using ZooLib.Core.Animals;
using ZooLib.Enums;
namespace ZooLib.Extensions
{
   public static class RepositoryQueries
    {
        
        public static IEnumerable<IGrouping<Type, IAnimal>> GroupByType(this IAnimalsRepository repository)
        {
            var animals = repository.GetAll();
            var query = animals.GroupBy(a => a.GetType());
            return query;
        }
        public static IEnumerable<IAnimal> GetByState(this IAnimalsRepository repository, AnimalState state)
        {
            var animals = repository.GetAll();
            var query = animals.Where(a => a.State == state);
            return query;
        }
        public static IEnumerable<IAnimal> GetSickTigers(this IAnimalsRepository repository)
        {
            var animals = repository.GetAll();
            var query = animals.Where(a => a.GetType() == typeof(Tiger) && a.State == AnimalState.Sick);
            return query;
        }
        public static IEnumerable<IAnimal> GetElephantByName(this IAnimalsRepository repository, string name)
        {
            var animals = repository.GetAll();
            var query = animals.Where(a => a.Name == name);
            return query;
        }
        public static IEnumerable<string> GetAllHungry(this IAnimalsRepository repository)
        {
            var animals = repository.GetAll();
            var query = from animal in animals
                        where animal.State == AnimalState.Hungry
                        select animal.Name;
            return query;
        }
        public static IEnumerable<IGrouping<Type, IAnimal>> GetMostHealthyInEachType(this IAnimalsRepository repository)
        {
            var query = repository.GroupByType().GroupBy(g=>g.Key,el=>el.First(e => e.Health==el.Max(x=>x.Health)));
            return query;
        }
        public static IEnumerable<IGrouping<Type, int>> GetDeadAnimalsCount(this IAnimalsRepository repository)
        {
            var query = repository.GroupByType()
                        .GroupBy(g => g.Key, e => e.Count(a => a.State == AnimalState.Dead));
            return query;
        }
        public static IEnumerable<IAnimal> GetWolvesAndBearsHealthMore3(this IAnimalsRepository repository)
        {
            var animals = repository.GetAll();
            var query = animals.Where(a => a.Health > 3 && (a.GetType() == typeof(Wolf) || a.GetType() == typeof(Bear)));
            return query;
        }
        public static IEnumerable<IAnimal> GetMinMaxHealth(this IAnimalsRepository repository)
        {
            var animals = repository.GetAll();
            var query = animals.Where(a => a.Health == animals.Max(m => m.Health) || a.Health == animals.Min(m => m.Health));
            return query;
        }
        public static double GetAverageHealth(this IAnimalsRepository repository)
        {
            var animals = repository.GetAll();
            var query = animals.Average(a => a.Health);
            return query;
        }
    }
}
