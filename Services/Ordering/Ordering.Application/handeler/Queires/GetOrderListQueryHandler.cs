using AutoMapper;
using Discount.Application.Queires;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.ResponseDto;
using Ordering.Core.IRpositries;

namespace Discount.Application.handeler.Queires
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, IList<OrderResponse>>
    {


        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepositry;
        private readonly ILogger<GetOrderListQueryHandler> logger;





        public GetOrderListQueryHandler(IMapper Mapper, IOrderRepository oderRepositry, ILogger<GetOrderListQueryHandler> logger)
        {
            _mapper = Mapper;
            _orderRepositry = oderRepositry;
            this.logger = logger;
        }
        public async Task<IList<OrderResponse>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var OrderList = await _orderRepositry.GetOrderByUserName(request.UserName);

            return _mapper.Map<IList<OrderResponse>>(OrderList.ToList());


        }
    }
}
