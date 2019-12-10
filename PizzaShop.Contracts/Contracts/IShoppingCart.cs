using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public interface IShoppingCart
    {
        public List<CartItem> CartItems { get; set; }
        public double Value { get; set; }
    }
}
