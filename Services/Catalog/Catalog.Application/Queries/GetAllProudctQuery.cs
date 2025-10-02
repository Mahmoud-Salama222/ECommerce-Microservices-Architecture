using Catalog.Application.Response;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllProudctQuery : IRequest<IList<ProudctResponseDto>>
    {

    }
}
