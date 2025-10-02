using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Entities;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.Queires
{
    public class GetAllTypeHandlerQuery : IRequestHandler<GetAllTypeQuery, IList<TypeResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITypeRepository _typeRepositry;



        public GetAllTypeHandlerQuery(IMapper Mapper, ITypeRepository typeRepositry)
        {
            _mapper = Mapper;
            _typeRepositry = typeRepositry;

        }
        public async Task<IList<TypeResponseDto>> Handle(GetAllTypeQuery request, CancellationToken cancellationToken)
        {
            var ProudctTypes = await _typeRepositry.GetAllTypes();
            var TypeResponseDto = _mapper.Map<IList<ProudctType>, IList<TypeResponseDto>>(ProudctTypes.ToList());
            return TypeResponseDto;
        }
    }
}
