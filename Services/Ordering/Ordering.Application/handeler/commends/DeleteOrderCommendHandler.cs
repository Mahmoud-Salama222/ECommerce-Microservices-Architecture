using AutoMapper;
using Discount.Application.commends;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Exceptions;
using Ordering.Core.IRpositries;

namespace Ordering.Application.handeler.commends
{
    public class DeleteOrderCommendHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {


        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepositry;
        private readonly ILogger<DeleteOrderCommendHandler> _logger;



        public DeleteOrderCommendHandler(IMapper Mapper, IOrderRepository orderRepositry, ILogger<DeleteOrderCommendHandler>logger)
        {
            _mapper = Mapper;

            _orderRepositry = orderRepositry;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {



            var order = await _orderRepositry.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new OrderNotFoundException(nameof(order), request.Id);
            }
            await _orderRepositry.DeleteAsync(order);
            _logger.LogInformation($"Order With Id{order.Id} deleted Sucessfuly ");


            return Unit.Value;
        }
    }
}
