using Catalog.Application.Response;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProudctByNameQuery : IRequest<IList<ProudctResponseDto>>
    {
        public string Name { get; set; }

        public GetProudctByNameQuery(string Name)
        {
            this.Name = Name;
        }

    }
}
