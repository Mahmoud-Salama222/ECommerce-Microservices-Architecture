using AutoMapper;
using Catalog.Application.commends;
using Discount.Application.Response;
using Discount.Core.Entities;
using Discount.Core.Repositries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Catalog.Application.handeler.commends
{
    public class CreateDiscountCommendHandler : IRequestHandler<CreateCouponCommend, CouponModel>
    {


        private readonly IMapper _mapper;
        private readonly IDiscountRepository discountRepository;



        public CreateDiscountCommendHandler(IMapper Mapper, IDiscountRepository discountRepository)
        {
            _mapper = Mapper;
            this.discountRepository = discountRepository;

        }
        public async Task<CouponModel> Handle(CreateCouponCommend request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(request);

            var createCoupon = await discountRepository.CreateCoupon(coupon);
            if (createCoupon == null)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Discount Not create"));

            }
            var couponModel = _mapper.Map<CouponModel>(createCoupon);
            return couponModel;


        }
    }
}
