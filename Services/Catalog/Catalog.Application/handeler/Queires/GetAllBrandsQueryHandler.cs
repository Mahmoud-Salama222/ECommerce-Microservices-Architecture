using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Entities;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.Queires
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandQuery, IList<BrandResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;



        public GetAllBrandsQueryHandler(IMapper Mapper, IBrandRepository brandRepository)
        {
            _mapper = Mapper;
            _brandRepository = brandRepository;

        }

        public async Task<IList<BrandResponseDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllBrands();
            var brandResponseDto = _mapper.Map<IList<ProudctBrand>, IList<BrandResponseDto>>(brands.ToList());
            return brandResponseDto;
        }
    }
}
