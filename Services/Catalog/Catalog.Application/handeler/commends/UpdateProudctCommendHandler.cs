using AutoMapper;
using Catalog.Application.commends;
using Catalog.Core.Entities;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.commends
{
    public class UpdateProudctCommendHandler : IRequestHandler<UpdateProudctCommend, bool>
    {


        private readonly IMapper _mapper;
        private readonly IProudctRepositories _proudctRepository;



        public UpdateProudctCommendHandler(IMapper Mapper, IProudctRepositories proudctRepository)
        {
            _mapper = Mapper;
            _proudctRepository = proudctRepository;

        }
        public async Task<bool> Handle(UpdateProudctCommend request, CancellationToken cancellationToken)
        {


            var ProudctEntity = _mapper.Map<UpdateProudctCommend, Proudct>(request);

            bool isUpdated = await _proudctRepository.UpdateProudct(ProudctEntity);


            return isUpdated;

        }
    }
}
