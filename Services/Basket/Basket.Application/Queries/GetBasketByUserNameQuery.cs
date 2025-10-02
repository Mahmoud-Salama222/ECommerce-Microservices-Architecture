using Basket.Application.Response;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Queries
{
    public class GetBasketByUserNameQuery : IRequest<ShoppingCardResponse>
    {
        public string UserName { get; set; }
        public GetBasketByUserNameQuery(string UserName)
        {
            this.UserName = UserName;
        }
    }
}
