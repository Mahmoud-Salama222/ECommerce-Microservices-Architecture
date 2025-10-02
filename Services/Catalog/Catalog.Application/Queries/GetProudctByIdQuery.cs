using Catalog.Application.Response;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProudctByIdQuery : IRequest<ProudctResponseDto>
    {
        public string Id { get; set; }

        public GetProudctByIdQuery(string Id)
        {
            this.Id = Id;
        }

    }
}
