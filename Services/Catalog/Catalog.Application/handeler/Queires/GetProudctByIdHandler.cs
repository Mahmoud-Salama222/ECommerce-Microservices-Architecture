using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Entities;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.Queires
{
    public class GetProudctByIdHandler : IRequestHandler<GetProudctByIdQuery, ProudctResponseDto>
    {


        private readonly IMapper _mapper;
        private readonly IProudctRepositories _proudctRepository;



        public GetProudctByIdHandler(IMapper Mapper, IProudctRepositories proudctRepository)
        {
            _mapper = Mapper;
            _proudctRepository = proudctRepository;

        }
        public async Task<ProudctResponseDto> Handle(GetProudctByIdQuery request, CancellationToken cancellationToken)
        {
            var proudct = await _proudctRepository.GetProudctById(request.Id);
            var proudctResponseDto = _mapper.Map<Proudct, ProudctResponseDto>(proudct);
            return proudctResponseDto;

        }
    }
}
