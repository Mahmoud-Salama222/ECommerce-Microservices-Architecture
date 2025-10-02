using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Repositries
{
    public interface IBasketRepository
    {
        Task<ShoppingCard> GetShoppingCart(string UserName);
        Task<ShoppingCard> UpdateShoppingCart(ShoppingCard shoppingCart);
        Task DeleteBasket(string UserName);


    }
}
