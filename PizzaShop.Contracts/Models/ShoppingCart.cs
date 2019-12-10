using PizzaShop.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public class ShoppingCartModel : IShoppingCart
    {
        public List<CartItem> CartItems { get; set; }
        public double Value { get; set; }
    }
}
