using Catalog.Application.commends;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Paganation;
using Catalog.Core.Repositries;
using Catalog.Core.Spec;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Api.Controllers
{

    [ApiController]
    public class CatalogController : BaseApiController
    {

        private readonly IMediator _mediator;
        private readonly IProudctRepositories _proudctRepository;



        public CatalogController(IMediator mediator, IProudctRepositories proudctRepository)
        {
            _mediator = mediator;
            _proudctRepository = proudctRepository;

        }
        [HttpGet]
        [Route("[action]/{Id}", Name = "GetProudctById")]
        [ProducesResponseType(typeof(ProudctResponseDto), 200)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<ProudctResponseDto>> GetProudctById(string Id)
        {
            var query = new GetProudctByIdQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);



        }

        [HttpGet]
        [Route("GetProudctByName")]
        [ProducesResponseType(typeof(IList<ProudctResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<IList<ProudctResponseDto>>> GetProudctByName(string Name)
        {
            var query = new GetProudctByNameQuery(Name);
            var result = await _mediator.Send(query);
            return Ok(result);



        }
        [HttpGet]
        [Route("GetAllProudcts")]
        [ProducesResponseType(typeof(IList<ProudctResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<IList<ProudctResponseDto>>> GetAllProudcts()
        {
            var query = new GetAllProudctQuery();
            var result = await _mediator.Send(query);
            return Ok(result);



        }
        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<IList<BrandResponseDto>>> GetAllBrands()
        {
            var query = new GetAllBrandQuery();
            var result = await _mediator.Send(query);
            return Ok(result);



        }
        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypeResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<IList<TypeResponseDto>>> GetAllTypes()
        {
            var query = new GetAllTypeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);



        }

        [HttpPost]
        [Route("CreateProudct")]
        [ProducesResponseType(typeof(ProudctResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<IList<ProudctResponseDto>>> CreateProudct([FromBody] CreateProudctCommend createProudctCommend)
        {

            var result = await _mediator.Send<ProudctResponseDto>(createProudctCommend);
            return Ok(result);



        }
        [HttpPut]
        [Route("UpdateProudct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<bool>> UpdateProudct([FromBody] UpdateProudctCommend updateProudctCommend)
        {
            var result = await _mediator.Send<bool>(updateProudctCommend);
            return Ok(result);



        }

        [HttpDelete]
        [Route("[action]/{Id}", Name = "DeleteProudct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<bool>> DeleteProudct(string Id)
        {
            var commend = new DeleteProudctCommend(Id);
            var result = await _mediator.Send<bool>(commend);
            return Ok(result);



        }
        [HttpGet]
        [Route("GetAllProudctWithSpecParams")]
        public async Task<ActionResult<Paganation<ProudctResponseDto>>> GetAllProudctWithSpecParams([FromQuery] CatalogSpecParams specParams)
        {
            var getAllProudctQueryWithSpecParams = new GetAllProudctQueryWithSpecParams(specParams);
            var result = await _mediator.Send(getAllProudctQueryWithSpecParams);
            return Ok(result);
        }

    }
}
