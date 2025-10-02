using Basket.Application.Response;
using Basket.Core.Entities;
using Basket.Core.Repositries;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Basket.Infrastructure.Repositries
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCash;

        public BasketRepository(IDistributedCache distributedCache)
        {
            this._redisCash = distributedCache;
        }
        public async Task<ShoppingCard> GetShoppingCart(string UserName)
        {

            var basket = _redisCash.GetString(UserName);
            if (string.IsNullOrEmpty(basket))
            {



                return null;
            }
            var basketObj = JsonConvert.DeserializeObject<ShoppingCard>(basket);


            return basketObj;
        }

        public async Task DeleteBasket(string UserName)
        {
            var basket = _redisCash.GetString(UserName);
            if (basket != null)
            {
                await _redisCash.RemoveAsync(UserName);


            }

        }


        public async Task<ShoppingCard> UpdateShoppingCart(ShoppingCard shoppingCart)
        {
            if (await GetShoppingCart(shoppingCart.UserName) == null)
            {


                await _redisCash.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
                return await GetShoppingCart(shoppingCart.UserName);
            }
            else
            {

                return await GetShoppingCart(shoppingCart.UserName);
            }
        }
    }
}
