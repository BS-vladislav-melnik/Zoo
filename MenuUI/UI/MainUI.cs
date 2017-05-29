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
namespace Zoo.UI
{
   public class MainUI
    {
        private ZooService _service;
        public MainUI(ZooService service)
        {
            _service = service;
            _service.AllDead += AllDead;
            _service.StateChanged += StateLog;
            Task.Run(()=> _service.FastingProcess());
        }
        private void AllDead()
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("All of your animals are dead. Game over.");
            Environment.Exit(0);
        }
        private void StateLog(AnimalState state, int health, string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} changed its state to {1} and {2} hp",name,state,health);
            Console.ResetColor();

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
                    string input = Console.ReadLine();
                    int option;
                    int.TryParse(input, out option);
                    switch (option)
                    {
                        case 1:
                            Add();
                            break;
                        case 2:
                            Feed();
                            break;
                        case 3:
                            Heal();
                            break;
                        case 4:
                            Remove();
                            break;
                        default:
                            break;
                    }
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
            string type, name;
            name = GetName();
            Console.WriteLine("Input Type:");
            type = Console.ReadLine();
            _service.Add(name, type);
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

            _service.Remove(GetName());
        }
        private string GetName()
        {
            Console.WriteLine("Input Name:");
            return Console.ReadLine();
        }
    }
}
