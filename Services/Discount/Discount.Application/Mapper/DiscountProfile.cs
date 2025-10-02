using AutoMapper;
using Catalog.Application.commends;
using Discount.Application.commends;
using Discount.Core.Entities;
using Discount.Grpc.Protos;

namespace Catalog.Application.Mapper
{
    public class DiscountProfile : Profile
    {

        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
            CreateMap<Coupon, CreateCouponCommend>().ReverseMap();
            CreateMap<Coupon, UpdateCouponCommend>().ReverseMap();



        }
    }
}
