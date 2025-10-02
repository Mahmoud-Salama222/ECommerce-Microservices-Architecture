using AutoMapper;
using Discount.Application.Queires;
using Discount.Application.Response;
using Discount.Core.Repositries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Discount.Application.handeler.Queires
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
    {


        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;
        private readonly ILogger<GetDiscountQueryHandler> logger;





        public GetDiscountQueryHandler(IMapper Mapper, IDiscountRepository discountRepository, ILogger<GetDiscountQueryHandler> logger)
        {
            _mapper = Mapper;
            _discountRepository = discountRepository;
            this.logger = logger;
        }
        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _discountRepository.GetDiscount(request.ProductName);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Discount Not Found"));

            }
            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;

        }
    }
}
