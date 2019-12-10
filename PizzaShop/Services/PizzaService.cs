using BookingEngine.Services;
using Newtonsoft.Json;
using PizzaShop.Contracts;
using ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Services
{
    public class PizzaService : IPizzaService
    {
        private List<Pizza> Pizzas = null;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IBookingService _bookingService;

        public PizzaService()
        {
            InitPizzaList();
            _shoppingCartService = new ShoppingCartService();
            _bookingService = new BookingService();
        }
        public async Task<bool> AddPizzaToCart(Pizza pizza, int quantity)
        {
            try
            {
                CartItem cartItem = new CartItem()
                {
                    Pizza = pizza,
                    Quantity = quantity
                };
                cartItem.TotalCost = pizza.Price * quantity;
                await _shoppingCartService.AddToCart(cartItem);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Pizza> GetMenu()
        {
            return Pizzas;
        }

        public async Task<bool> PlaceOrder()
        {
            var cart = _shoppingCartService.GetCart();
            if (cart is null)
            {
                return false;
            }
            _bookingService.PlaceOrder(cart);
            return true;
        }

        private void InitPizzaList()
        {
            string dummyPizzas = string.Empty;
            using (StreamReader reader = new StreamReader($"{Directory.GetCurrentDirectory()}"+@"\Data\DummyPizza.json"))
            {
                dummyPizzas = reader.ReadToEnd();
            }
            Pizzas = JsonConvert.DeserializeObject<List<Pizza>>(dummyPizzas);
        }

        public void ViewCart()
        {
            _shoppingCartService.ShowCartItems();
        }
    }
}
