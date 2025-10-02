using AutoMapper;

using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Commends;
using Ordering.Core.Entities;
using Ordering.Core.IRpositries;

namespace Ordering.Application.handeler.commends
{
    public class CheckoutOrderCommendHandler : IRequestHandler<CheckoutOrderCommand, int>
    {


        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepositry;
        private readonly ILogger<CheckoutOrderCommendHandler> _logger;



        public CheckoutOrderCommendHandler(IMapper Mapper, IOrderRepository _orderRepositry, ILogger<CheckoutOrderCommendHandler> logger)
        {
            _mapper = Mapper;
            this._orderRepositry = _orderRepositry;
            _logger = logger;
        }
        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);

            var createOrder = await _orderRepositry.AddAsync(order);
            _logger.LogInformation($"Order With Id{createOrder.Id} genrateated ");


            return createOrder.Id;


        }
    }
}
