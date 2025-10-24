using AutoMapper;
using Basket.Api.Controllers;
using Basket.Application.Commends;
using Basket.Application.Queries;
using Basket.Application.Response;
using Basket.Core.Entities;
using Basket.Core.Repositries;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{

    [ApiController]
    public class BasketController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IBasketRepository _basketRepository;
        private readonly IPublishEndpoint _publisherEndpoint;
        private readonly IMapper _mapper;


        public BasketController(IMediator mediator,
            IBasketRepository basketRepository,
            IPublishEndpoint publisherEndpoint,
            IMapper mapper)
        {
            _mediator = mediator;
            _basketRepository = basketRepository;
            _publisherEndpoint = publisherEndpoint;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CheckOut")]
        public async Task<ActionResult> CheckOut(BasketCheckout basketCheckout)
        {

            var query = new GetBasketByUserNameQuery(basketCheckout.UserName);
            var basket = await _mediator.Send(query);
            if (basket == null)
            {
                return BadRequest();
            }
            var eventmessage = _mapper.Map<BasketCheckOutEvent>(basketCheckout);
            eventmessage.TotalPrice = basket.TotalPrice;
            await _publisherEndpoint.Publish(eventmessage); // publish so can order services consume and order
            var deletedcommend = new DeleteBasketByUserNameCommend(basketCheckout.UserName);
            await _mediator.Send(deletedcommend);
            return Accepted();
        }

        [HttpGet]
        [Route("[action]/{userName}", Name = "GetBasketByUserName")]
        //[ProducesResponseType(typeof(ShoppingCardResponse), 200)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<ShoppingCardResponse>> GetBasketByUserName(string userName)
        {
            var query = new GetBasketByUserNameQuery(userName);
            var basket = await _mediator.Send(query);
            return Ok(basket);
        }


        [HttpPost]
        [Route("CreateOrUpdateBasket")]


        public async Task<ActionResult<ShoppingCardResponse>> CreateOrUpdateBasket([FromBody] CreateShoppingCardCommend createShoppingCardCommend)
        {

            var result = await _mediator.Send(createShoppingCardCommend);
            return Ok(result);


        }


        [HttpDelete]
        [Route("[action]/{userName}", Name = "DeleteBasket")]


        public async Task<ActionResult<Unit>> DeleteBasket(string userName)
        {
            var commend = new DeleteBasketByUserNameCommend(userName);
            var result = await _mediator.Send(commend);
            return Ok(result);

        }


    }
}
