using System;
using System.Collections.Generic;
using System.Text;
using PizzaShop.Contracts;

namespace BookingEngine.Services
{
    public class BookingService : IBookingService
    {
        public void PlaceOrder(ShoppingCartModel cart)
        {
            Console.WriteLine("Order has been placed for your cart!\nTotal Value: "+ cart.Value);
        }
    }
}
