using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using ZooLib.Interfaces;
using ZooLib.Core;
using ZooLib.Exceptions;
using ZooLib.Enums;
using MenuUI.Infrastructure;
using ZooLib.Extensions;
namespace MenuUI.UI
{
   public class MainUI
    {
        private readonly ZooService _service;

        private readonly Dictionary<int, Action> _UIactions=new Dictionary<int, Action>();
        public event StringMessage Message;

        public MainUI(ZooService service)
        {
            _service = service;
            _service.AllDead += AllDead;
            _service.StateChanged += StateLog;
            Task.Run(() => _service.FastingProcess());
            _UIactions.Add(1, Add);
            _UIactions.Add(2, Feed);
            _UIactions.Add(3, Heal);
            _UIactions.Add(4, Remove);
            _UIactions.Add(5, GroupByType);
            _UIactions.Add(6, GetByState);
            _UIactions.Add(7, GetSickTigers);
            _UIactions.Add(8, GetElephantByName);
            _UIactions.Add(9, GetAllHungry);
            _UIactions.Add(10, GetMostHealthyInEachType);
            _UIactions.Add(11, GetDeadAnimalsCount);
            _UIactions.Add(12, GetWolvesAndBearsHealthMore3);
            _UIactions.Add(13, GetMinMaxHealth);
            _UIactions.Add(14, GetAverageHealth);
        }
        private void AllDead()
        {
            Message?.Invoke("All of your animals are dead. Game over.", ConsoleColor.Red);
            Environment.Exit(0);
        }
        private void StateLog(AnimalState state, int health, string name)
        {            
            Message?.Invoke(String.Format("{0} changed its state to {1} and {2} hp", name, state, health), ConsoleColor.Green);
        }
        public void Menu()
        {
       
            while (true)
            {
                try
                {

                    Console.WriteLine("Select option:");
                    Console.WriteLine("1 - Add animal");
                    Console.WriteLine("2 - Feed animal");
                    Console.WriteLine("3 - Heal animal");
                    Console.WriteLine("4 - Remove animal");
                    Console.WriteLine("5 - Grouped by type");
                    Console.WriteLine("6 - Get by state");
                    Console.WriteLine("7 - Get sick tigers");
                    Console.WriteLine("8 - Get elephant by name");
                    Console.WriteLine("9 - Hungry animals");
                    Console.WriteLine("10 - Most healthy in each type");
                    Console.WriteLine("11 - Dead in each type");
                    Console.WriteLine("12 - Wolves and bears with hp>3");
                    Console.WriteLine("13 - Animals with min or max health");
                    Console.WriteLine("14 - Average health in park");
                    var input = Console.ReadLine();
                    int option;
                    int.TryParse(input, out option);
                            _UIactions[option].Invoke();
                }

                catch (AnimalDeadException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }

        }
        private void Add()
        {
            var name = GetName();
            Console.WriteLine("Input Type:");
            var type = Console.ReadLine();
            _service.Repository.Add(name, type);
        }
        private void Feed()
        {
            _service.Feed(GetName());
        }
        private void Heal()
        {
            _service.Heal(GetName());
        }
        private void Remove()
        {

            _service.Repository.RemoveByName(GetName());
        }
        private string GetName()
        {
            Console.WriteLine("Input Name:");
            return Console.ReadLine();
        }
        private string AnimalListToString(IEnumerable<IAnimal> animals)
        {
            var result = string.Empty;
            foreach (var item in animals)
            {
                
                result += String.Format("\n\t Animal name is {0}\n\t State is:{1}\n\t Health is:{2}\n\t -----------------\n", item.Name, item.State, item.Health);
            }
            return result;
        }
        public void GroupByType()
        {
            var result= "Animal groups by type: \n";
            var animals = _service.Repository.GroupByType();
            foreach (var item in animals)
            {
                result += item.Key.Name + ":\n";
                result+= AnimalListToString(item);
                
            }
            Console.WriteLine(result);
        }
        public void GetByState()
        {
            var stateStr = Console.ReadLine();
            AnimalState state;
            if (Enum.TryParse(stateStr, out state)) {
                var result = "Animals by state: \n";
                var animals = _service.Repository.GetByState(state);
                result += AnimalListToString(animals);
                Console.WriteLine(result);
            }
        }
        public void GetSickTigers()
        {
            var result = "Sick tigers: \n";
            var animals = _service.Repository.GetSickTigers();
            result += AnimalListToString(animals);
            Console.WriteLine(result);
        }
        public void GetElephantByName()
        {
            var result = "Elephants by name: \n";
            var animals = _service.Repository.GetElephantByName(GetName());
            result += AnimalListToString(animals);
            Console.WriteLine(result);
        }
        public void GetAllHungry()
        {
            var result = "All hungry: \n";
            var animals = _service.Repository.GetAllHungry();
            foreach (var item in animals)
                result += "\t name:" + item + "\n";
            Console.WriteLine(result);
        }
        public void GetMostHealthyInEachType()
        {
            var result = "Most healthy in type: \n";
            var animals = _service.Repository.GetMostHealthyInEachType();
            foreach (var item in animals)
            {
                result += item.Key.Name + ":\n";
                result += AnimalListToString(item);
            }
            Console.WriteLine(result);
        }
        public void GetDeadAnimalsCount()
        {
            var result = "Dead animals count: \n";
            var animals = _service.Repository.GetDeadAnimalsCount();
            foreach (var item in animals)
            {
                result += item.Key.Name + ":\n";
                foreach (var animal in item)
                {
                    result += "\t Count:" + animal + "\n";
                }
            }
            Console.WriteLine(result);
        }
        public void GetWolvesAndBearsHealthMore3()
        {
            var result = "Wolves and bears that have more than 3 hp: \n";
            var animals = _service.Repository.GetWolvesAndBearsHealthMore3();
            result += AnimalListToString(animals);
            Console.WriteLine(result);
        }
        public void GetMinMaxHealth()
        {
            var result = "Animals that have min or max health: \n";
            var animals = _service.Repository.GetMinMaxHealth();
            result += AnimalListToString(animals);
            Console.WriteLine(result);
        }
        public void GetAverageHealth()
        {
            var result = "Average health: \n";
            var avg = _service.Repository.GetAverageHealth();
                result += "\t value:" + avg + "\n";
            Console.WriteLine(result);
        }
    }
}
