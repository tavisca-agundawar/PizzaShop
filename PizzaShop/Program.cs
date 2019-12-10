using Newtonsoft.Json;
using PizzaShop.Contracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace PizzaShop
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaShop pizzaShop = new PizzaShop();
            pizzaShop.Run();
        }
    }
}
