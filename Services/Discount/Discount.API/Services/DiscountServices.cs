using Catalog.Application.commends;
using Discount.Application.commends;
using Discount.Application.Queires;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.API.Services
{
    public class DiscountServices : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IMediator _mediator;




        public DiscountServices(IMediator mediator)
        {
            _mediator = mediator;


        }
        public async override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var query = new GetDiscountQuery(request.ProductName);
            var result = await _mediator.Send<CouponModel>(query);
            return result;
        }
        public async override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var commend = new CreateCouponCommend
            {
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount,

            };
            var result = await _mediator.Send(commend);
            return result;
        }

        public async override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var commend = new UpdateCouponCommend
            {
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount,

            };
            var result = await _mediator.Send(commend);
            return result;
        }

        public async override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var commend = new DeleteCouponCommend(request.ProductName);

            var result = await _mediator.Send(commend);

            var response = new DeleteDiscountResponse
            {
                Success = true,
            };
            return response;
        }
    }
}
