using Basket.Application.Response;
using Basket.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commends
{
    public class CreateShoppingCardCommend : IRequest<ShoppingCardResponse>
    {
        public string UserName { get; set; }
        public List<ShoppingCardItem> Items { get; set; }

    }
}
