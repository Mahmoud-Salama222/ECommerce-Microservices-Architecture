using AutoMapper;

using MediatR;
using Ordering.Application.ResponseDto;

namespace Discount.Application.Queires
{
    public class GetOrderListQuery : IRequest<IList<OrderResponse>>
    {

        public string UserName { get; set; }
        public GetOrderListQuery(string userName)
        {
            this.UserName = userName;
        }

    }
}
