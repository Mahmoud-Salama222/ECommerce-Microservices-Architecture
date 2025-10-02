using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Entities;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.Queires
{
    public class GetProudctByNameHandler : IRequestHandler<GetProudctByNameQuery, IList<ProudctResponseDto>>
    {


        private readonly IMapper _mapper;
        private readonly IProudctRepositories _proudctRepository;



        public GetProudctByNameHandler(IMapper Mapper, IProudctRepositories proudctRepository)
        {
            _mapper = Mapper;
            _proudctRepository = proudctRepository;

        }
        public async Task<IList<ProudctResponseDto>> Handle(GetProudctByNameQuery request, CancellationToken cancellationToken)
        {
            var proudcts = await _proudctRepository.GetAllProudctByName(request.Name);
            var proudctResponseDto = _mapper.Map<IList<Proudct>, IList<ProudctResponseDto>>(proudcts.ToList());
            return proudctResponseDto;

        }
    }
}
