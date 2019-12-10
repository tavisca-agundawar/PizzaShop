using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public interface IPizza : IFoodItem
    {
        List<Topping> Toppings { get; set; }
        string Base { get; set; }
    }
}
