using System;
using System.Collections.Generic;
using System.Text;
using PizzaShop.Contracts;
using PizzaShop.Services;

namespace PizzaShop
{
    public class PizzaShop
    {
        private readonly IPizzaService _pizzaService;
        private readonly DisplayService _display;
        private readonly List<string> choices;
        public PizzaShop()
        {
            _pizzaService = new PizzaService();
            _display = new DisplayService();
            choices = new List<string>();
            var ch = Enum.GetNames(typeof(Choices));
            for (int i = 0; i < ch.Length; i++)
            {
                choices.Add(ch[i]);
            }
        }
        enum Choices
        {
            Menu,
            AddPizza,
            ViewCart,
            PlaceOrder,
            Exit
        }
        internal void Run()
        {
            bool stop = false;
            DisplayWelcomeMessage();
            while (!stop)
            {
                DisplayMainMenu();
                string option = GetChoice();
                if (string.IsNullOrEmpty(option))
                {
                    Console.WriteLine("Invalid choice!");
                }
                switch (option)
                {
                    case "Menu":
                        {
                            var pizzas = _pizzaService.GetMenu();
                            _display.Pizzas(pizzas);
                            break;
                        }
                    case "AddPizza":
                        {
                            var pizzas = _pizzaService.GetMenu();
                            Pizza choice = _display.PizzaChoices(pizzas);
                            int quantity = GetQuantity();
                            _pizzaService.AddPizzaToCart(choice, quantity);
                            _display.PizzaAdded(choice, quantity);
                            break;
                        }
                    case "ViewCart":
                        {
                            _pizzaService.ViewCart();
                            break;
                        }
                    case "PlaceOrder":
                        {
                            _pizzaService.PlaceOrder();
                            break;
                        }
                    case "Exit":
                        {
                            stop = true;
                            break;
                        }
                    default:
                        break;
                } 
            }
        }

        private int GetQuantity()
        {
            string value;
            int choice;
            Console.WriteLine("Enter quantity: ");
            while (true)
            {
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Value cannot be blank!");
                }
                else
                {
                    try
                    {
                        choice = Convert.ToInt32(value);
                        return choice;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid choice!");
                    }
                }
            }

        }
        private string GetChoice()
        {
            string value;
            int choice;
            while (true)
            {
                value = Console.ReadLine();
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Value cannot be blank!");
                }
                else
                {
                    break;
                }
            }
            try
            {
                choice = Convert.ToInt32(value);
                return choices[choice-1];
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid choice!");
            }
            return null;
        }
        private void DisplayMainMenu()
        {
            Console.WriteLine("Choose an opiton: ");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine((i+1)+"."+choices[i]);
            }
        }

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine(string.Format("{0,50}","Welcome to the Pizza Shop!"));
            Console.WriteLine("\n");
        }
    }
}
