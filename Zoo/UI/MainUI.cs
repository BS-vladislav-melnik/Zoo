using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Zoo.Interfaces;
using Zoo.Core;
using Zoo.Exceptions;
using Zoo.Enums;
namespace Zoo.UI
{
   public class MainUI
    {
        private IAnimalsRepository _repository;
        public MainUI(IAnimalsRepository repository)
        {
            _repository = repository;
            repository.AllDead += AllDead;
            repository.StateChanged += StateLog;
            Task.Run(()=> repository.FastingProcess());
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
            _repository.Add(name, type);
        }
        private void Feed()
        {
            _repository.Feed(GetName());
        }
        private void Heal()
        {
            _repository.Heal(GetName());
        }
        private void Remove()
        {
            
            _repository.Remove(GetName());
        }
        private string GetName()
        {
            Console.WriteLine("Input Name:");
            return Console.ReadLine();
        }
    }
}
