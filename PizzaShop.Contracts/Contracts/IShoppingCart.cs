using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public interface IShoppingCart
    {
        List<CartItem> CartItems { get; set; }
        double Value { get; set; }
    }
}
