using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Entities;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.Queires
{
    public class GetAllProudctsQueryHandler : IRequestHandler<GetAllProudctQuery, IList<ProudctResponseDto>>
    {


        private readonly IMapper _mapper;
        private readonly IProudctRepositories _proudctRepository;



        public GetAllProudctsQueryHandler(IMapper Mapper, IProudctRepositories proudctRepository)
        {
            _mapper = Mapper;
            _proudctRepository = proudctRepository;

        }
        public async Task<IList<ProudctResponseDto>> Handle(GetAllProudctQuery request, CancellationToken cancellationToken)
        {
            var proudcts = await _proudctRepository.GetAllProudcts();
            var proudctResponseDto = _mapper.Map<IList<Proudct>, IList<ProudctResponseDto>>(proudcts.ToList());
            return proudctResponseDto;
        }
    }
}
