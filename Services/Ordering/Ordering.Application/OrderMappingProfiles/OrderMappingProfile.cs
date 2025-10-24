using AutoMapper;
using Discount.Application.commends;
using EventBus.Messages.Events;
using Ordering.Application.Commends;
using Ordering.Application.ResponseDto;
using Ordering.Core.Entities;

namespace Ordering.Application.OrderMappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<Order, DeleteOrderCommand>().ReverseMap();
            CreateMap<CheckoutOrderCommand, BasketCheckOutEvent>().ReverseMap();






        }
    }
}
