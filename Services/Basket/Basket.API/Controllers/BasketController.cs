using Basket.Api.Controllers;
using Basket.Application.Commends;
using Basket.Application.Queries;
using Basket.Application.Response;
using Basket.Core.Repositries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{

    [ApiController]
    public class BasketController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IBasketRepository _basketRepository;



        public BasketController(IMediator mediator, IBasketRepository basketRepository)
        {
            _mediator = mediator;
            _basketRepository = basketRepository;

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
