using AutoMapper;
using Catalog.Application.commends;
using Catalog.Application.Response;
using Catalog.Core.Entities;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.commends
{
    public class CreateProudctCommendHandler : IRequestHandler<CreateProudctCommend, ProudctResponseDto>
    {


        private readonly IMapper _mapper;
        private readonly IProudctRepositories _proudctRepository;



        public CreateProudctCommendHandler(IMapper Mapper, IProudctRepositories proudctRepository)
        {
            _mapper = Mapper;
            _proudctRepository = proudctRepository;

        }
        public async Task<ProudctResponseDto> Handle(CreateProudctCommend request, CancellationToken cancellationToken)
        {
            var ProudctEntity = _mapper.Map<CreateProudctCommend, Proudct>(request);

            var newProudct = await _proudctRepository.CreateProudct(ProudctEntity);

            var proudctResponseDto = _mapper.Map<Proudct, ProudctResponseDto>(newProudct);
            return proudctResponseDto;

        }
    }
}
