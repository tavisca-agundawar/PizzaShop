﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public interface IBookingService
    {
        void PlaceOrder(ShoppingCartModel cart);
    }
}
