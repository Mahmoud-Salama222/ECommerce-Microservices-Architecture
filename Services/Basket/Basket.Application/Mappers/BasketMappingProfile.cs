using AutoMapper;
using Basket.Application.Response;
using Basket.Core.Entities;
using EventBus.Messages.Events;

namespace Basket.Application.Mappers
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {

            CreateMap<ShoppingCard, ShoppingCardResponse>().ReverseMap();
            CreateMap<ShoppingCardItem, ShoppingCartItemResponse>().ReverseMap();
            CreateMap<BasketCheckout, BasketCheckOutEvent>().ReverseMap();




        }
    }
}
