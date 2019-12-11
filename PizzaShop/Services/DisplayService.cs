using PizzaShop.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Services
{
    public class DisplayService
    {
        public Pizza PizzaChoices(List<Pizza> pizzas)
        {
            string dashLine = "----------------------------------------------------------------------------" +
                "--------------------------------------------------------------------------";
            string format = "{0,-10} | {1,-35} | {1,-30} | {2,-35} | {3,-10}";
            Console.WriteLine(dashLine);
            Console.WriteLine(string.Format(format, "Sr. No.".PadLeft(3, ' '), "Name", "Toppings","Category", "Price"));
            Console.WriteLine(dashLine);
            for (int i = 0; i < pizzas.Count; i++)
            {
                Console.WriteLine(string.Format(format, $"{i + 1}.".PadLeft(5, ' '), 
                                                pizzas[i].Name, 
                                                GetToppingsString(pizzas[i].Toppings),
                                                pizzas[i].Category,
                                                $"${pizzas[i].Price.ToString()}"));
            }
            Console.WriteLine(dashLine);
            Console.WriteLine("Enter choice: ");
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
                    try
                    {
                        choice = Convert.ToInt32(value);
                        var pizza = pizzas[choice];
                        return pizza;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid choice!");
                    }
                }
            }
        }
        public void Pizzas(List<Pizza> pizzas)
        {
            string dashLine = "--------------------------------------------------------------------------------------------" +
                "------------------------------------------------------------------------------";
            string format = "{0,-45} | {1,-30} | {2,-35} | {3,-25} | {4,-10}";
            Console.WriteLine(dashLine);
            Console.WriteLine(string.Format(format,
                              "Name", "Category", "Toppings", "Base", "Price"));
            Console.WriteLine(dashLine);
            for (int i = 0; i < pizzas.Count; i++)
            {
                Console.WriteLine(
                                    string.Format
                                    (
                                        format, 
                                        pizzas[i].Name, 
                                        pizzas[i].Category, 
                                        GetToppingsString(pizzas[i].Toppings), 
                                        pizzas[i].Base,
                                        pizzas[i].Price 
                                    )
                                  );
            }
            Console.WriteLine(dashLine);
        }

        internal void PizzaAdded(Pizza choice, int quantity)
        {
            string dashLine = "--------------------------------------------------------------------------------------------" +
                "--------------------------------------------------------------------";
            string format = "{0,-35} | {1,-30} | {2,-30} | {3,-25} | {4,-10} | {5,-10}";

            Console.WriteLine("Added to cart: ");
            Console.WriteLine(dashLine);
            Console.WriteLine(string.Format(format,
                              "Name", "Category", "Toppings", "Base", "Price/Unit", "Quantity"));
            Console.WriteLine(dashLine);
            Console.WriteLine(
                                    string.Format
                                    (
                                        format,
                                        choice.Name,
                                        choice.Category,
                                        GetToppingsString(choice.Toppings),
                                        choice.Base,
                                        choice.Price,
                                        quantity
                                    )
                                  );
            Console.WriteLine(dashLine);
        }

        private string GetToppingsString(List<Topping> toppings)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < toppings.Count; i++)
            {
                builder.Append(toppings[i].Name);
                if (i != toppings.Count - 1)
                {
                    builder.Append(", ");
                }
            }
            return builder.ToString();
        }
    }
}
