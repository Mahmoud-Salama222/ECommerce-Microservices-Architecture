using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.Queires
{
    public class GetProudctByBrandHandler : IRequestHandler<GetProudctByBrandQuery, IList<ProudctResponseDto>>
    {


        private readonly IMapper _mapper;
        private readonly IProudctRepositories _proudctRepository;



        public GetProudctByBrandHandler(IMapper Mapper, IProudctRepositories proudctRepository)
        {
            _mapper = Mapper;
            _proudctRepository = proudctRepository;

        }
        public async Task<IList<ProudctResponseDto>> Handle(GetProudctByBrandQuery request, CancellationToken cancellationToken)
        {
            var proudcts = await _proudctRepository.GetAllProudctByBrand(request.Name);
            var proudctResponseDto = _mapper.Map<IList<ProudctResponseDto>>(proudcts.ToList());
            return proudctResponseDto;
        }
    }
}
