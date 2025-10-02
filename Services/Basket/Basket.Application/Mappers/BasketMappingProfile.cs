using AutoMapper;
using Basket.Application.Response;
using Basket.Core.Entities;
using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Mappers
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {

            CreateMap<ShoppingCard, ShoppingCardResponse>().ReverseMap();
            CreateMap<ShoppingCardItem, ShoppingCartItemResponse>().ReverseMap();



        }
    }
}
