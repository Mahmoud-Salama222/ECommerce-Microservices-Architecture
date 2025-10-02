using AutoMapper;
using Basket.Application.GrpcServices;
using Basket.Application.Response;
using Basket.Core.Repositries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commends
{
    public class CreateShoppingCardCommendHandler : IRequestHandler<CreateShoppingCardCommend, ShoppingCardResponse>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;
        private readonly DiscountGrpcService discountGrpcService;

        public CreateShoppingCardCommendHandler(IBasketRepository basketRepository, IMapper _mapper, DiscountGrpcService discountGrpcService)
        {
            this.basketRepository = basketRepository;
            mapper = _mapper;
            this.discountGrpcService = discountGrpcService;
        }
        public async Task<ShoppingCardResponse> Handle(CreateShoppingCardCommend request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Items)
            {
                var coupon = await discountGrpcService.GetDiscount(item.ProductName);

                if (coupon != null)
                {
                    item.Price -= coupon.Amount;
                }

            }



            var createOrupdateBasket = await basketRepository.UpdateShoppingCart(new Core.Entities.ShoppingCard
            {
                UserName = request.UserName,
                Items = request.Items,

            });


            var ShoppingCardResponse = mapper.Map<ShoppingCardResponse>(createOrupdateBasket);

            return ShoppingCardResponse;
        }
    }
}
