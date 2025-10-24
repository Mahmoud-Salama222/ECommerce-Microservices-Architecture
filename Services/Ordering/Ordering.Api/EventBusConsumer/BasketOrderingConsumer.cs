using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;

using MediatR;
using Ordering.Application.Commends;

namespace Ordering.API.EventBusConsumer
{
    public class BasketOrderingConsumer : IConsumer<BasketCheckOutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private readonly ILogger<BasketOrderingConsumer> _logger;

        public BasketOrderingConsumer(IMediator mediator,
            IMapper mapper,
            ILogger<BasketOrderingConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<BasketCheckOutEvent> context)
        {
            using var scope = _logger.BeginScope("Consume basket checkout event for correlationid", context.Message.CorrelationId);
            var cmd = _mapper.Map<CheckoutOrderCommand>(context.Message);
            //when event publish make consume and create order
            var result = await _mediator.Send(cmd);
            _logger.LogInformation("basket checkout event completed");
        }
    }
}
