using AutoMapper;
using Discount.Application.commends;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Exceptions;
using Ordering.Core.Entities;
using Ordering.Core.IRpositries;

namespace Ordering.Application.handeler.commends
{ 

    public class UpdateOrderCommendHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {


        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepositry;
        private readonly ILogger<UpdateOrderCommendHandler> _logger;



        public UpdateOrderCommendHandler(IMapper Mapper, IOrderRepository orderRepositry, ILogger<UpdateOrderCommendHandler> logger)
        {
            _mapper = Mapper;
            this._orderRepositry = orderRepositry;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepositry.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new OrderNotFoundException(nameof(order), request.Id);
            }
            _mapper.Map(request, order);

            await _orderRepositry.UpadteAsync(order);
            _logger.LogInformation($"Order With Id{order.Id} Updated Sucessfuly ");

            return Unit.Value;

        }
    }
}
