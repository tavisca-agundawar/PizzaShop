using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Contracts
{
    public interface IPizzaService
    {
        List<Pizza> GetMenu();
        Task<bool> AddPizzaToCart(Pizza pizza, int quantity);
        Task<bool> PlaceOrder();
        void ViewCart();
    }
}
