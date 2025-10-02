using AutoMapper;
using Catalog.Application.commends;
using Catalog.Core.Repositries;
using MediatR;

namespace Catalog.Application.handeler.commends
{
    public class DeleteProudctCommendHandler : IRequestHandler<DeleteProudctCommend, bool>
    {


        private readonly IMapper _mapper;
        private readonly IProudctRepositories _proudctRepository;



        public DeleteProudctCommendHandler(IMapper Mapper, IProudctRepositories proudctRepository)
        {
            _mapper = Mapper;
            _proudctRepository = proudctRepository;

        }
        public async Task<bool> Handle(DeleteProudctCommend request, CancellationToken cancellationToken)
        {


            bool isUpdated = await _proudctRepository.DeleteProudct(request.Id);


            return isUpdated;

        }
    }
}
