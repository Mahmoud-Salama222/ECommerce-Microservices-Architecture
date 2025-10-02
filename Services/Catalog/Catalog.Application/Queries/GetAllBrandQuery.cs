using Catalog.Application.Response;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllBrandQuery : IRequest<IList<BrandResponseDto>>
    {
    }
}
