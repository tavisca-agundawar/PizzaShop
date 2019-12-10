using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Contracts
{
    public interface IShoppingCartService
    {
        Task<bool> AddToCart(CartItem item);
        ShoppingCartModel GetCart();
        void ShowCartItems();
        void ClearCart();
    }
}
