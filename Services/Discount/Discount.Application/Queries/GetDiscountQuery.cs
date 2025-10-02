using AutoMapper;

using Discount.Application.Response;

using Discount.Core.Repositries;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Queires
{
    public class GetDiscountQuery : IRequest<CouponModel>
    {

        public string ProductName { get; set; }
        public GetDiscountQuery(string ProductName)
        {
            this.ProductName = ProductName;
        }

    }
}
