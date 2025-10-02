using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Response
{
    public class ShoppingCardResponse
    {
        public string UserName { get; set; }
        public List<ShoppingCartItemResponse> Items { get; set; }

        public ShoppingCardResponse(string userName)
        {
            UserName = userName;
        }
        public ShoppingCardResponse()
        {

        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }

    }
}
