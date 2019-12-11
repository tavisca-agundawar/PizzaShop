using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public class CartItem
    {
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
        public double TotalCost { get; set; }
    }
}
