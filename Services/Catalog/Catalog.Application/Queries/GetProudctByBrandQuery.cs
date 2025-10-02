using Catalog.Application.Response;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProudctByBrandQuery : IRequest<IList<ProudctResponseDto>>
    {
        public string Name { get; set; }
        public GetProudctByBrandQuery(string Name)
        {
            this.Name = Name;
        }
    }
}
