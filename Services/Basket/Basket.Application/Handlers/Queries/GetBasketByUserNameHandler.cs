using AutoMapper;
using Basket.Application.Queries;
using Basket.Application.Response;
using Basket.Core.Repositries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers.Queries
{
    public class GetBasketByUserNameHandler : IRequestHandler<GetBasketByUserNameQuery, ShoppingCardResponse>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public GetBasketByUserNameHandler(IBasketRepository basketRepository, IMapper _mapper)
        {
            this.basketRepository = basketRepository;
            mapper = _mapper;
        }
        public async Task<ShoppingCardResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var basket = await basketRepository.GetShoppingCart(request.UserName);
            Console.WriteLine(basket);

            var ShoppingCardResponse = mapper.Map<ShoppingCardResponse>(basket);
            Console.WriteLine(ShoppingCardResponse);
            return ShoppingCardResponse;
        }
    }
}
