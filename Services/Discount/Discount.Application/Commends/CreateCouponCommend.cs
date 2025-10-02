using Discount.Application.Response;
using Discount.Core.Entities;
using Discount.Grpc.Protos;
using MediatR;

namespace Catalog.Application.commends
{
    public class CreateCouponCommend : IRequest<CouponModel>
    {
        public string ProductName { get; set; }

        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
