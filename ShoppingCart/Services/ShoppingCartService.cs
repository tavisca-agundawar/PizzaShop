using PizzaShop.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ShoppingCartModel _shoppingCart;
        public ShoppingCartService()
        {
            _shoppingCart = new ShoppingCartModel();
        }
        public async Task<bool> AddToCart(CartItem item)
        {
            try
            {
                _shoppingCart.CartItems.Add(item);
                _shoppingCart.Value += item.TotalCost;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ShoppingCartModel GetCart()
        {
            return _shoppingCart;
        }

        public void ShowCartItems()
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-45} | {1,-10} | {2,-10}", "Pizza Name", "Quantity", "Cost"));
            Console.WriteLine("--------------------------------------------------------------------------");
            for (int i = 0; i < _shoppingCart.CartItems.Count; i++)
            {
                Console.WriteLine(string.Format("{0,-45} | {1,-10} | {2,-10}",
                                  _shoppingCart.CartItems[i].Pizza.Name,
                                  _shoppingCart.CartItems[i].Quantity,
                                  _shoppingCart.CartItems[i].TotalCost));
            }
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-45} | {1,-20}","Total Cost: ","$"+_shoppingCart.Value));
            Console.WriteLine("--------------------------------------------------------------------------");
        }

        public void ClearCart()
        {
            _shoppingCart.CartItems.Clear();
            _shoppingCart.Value = 0;
        }
    }
}
