using AutoMapper;
using Discount.Application.commends;
using Discount.Core.Entities;
using Discount.Core.Repositries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Catalog.Application.handeler.commends
{
    public class UpdateDiscountCommendHandler : IRequestHandler<UpdateCouponCommend, CouponModel>
    {


        private readonly IMapper _mapper;
        private readonly IDiscountRepository discountRepository;




        public UpdateDiscountCommendHandler(IMapper Mapper, IDiscountRepository discountRepository)
        {
            _mapper = Mapper;
            this.discountRepository = discountRepository;


        }
        public async Task<CouponModel> Handle(UpdateCouponCommend request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(request);

            var UpdateCoupon = await discountRepository.UpdateDiscount(coupon);
            if (UpdateCoupon == null)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Discount Not Update"));

            }
            var couponModel = _mapper.Map<CouponModel>(UpdateCoupon);
            return couponModel;

        }
    }
}
