using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public interface IFoodItem
    {
        string Name { get; set; }
        string Category { get; set; }
        bool IsNonVeg { get; set; }
        double Price { get; set; }
    }
}
