using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Entities;
using Catalog.Core.Paganation;
using Catalog.Core.Repositries;
using Catalog.Core.Spec;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.handeler.Queires
{
    public class GetAllProudctQueryWithSpecParamsHandler : IRequestHandler<GetAllProudctQueryWithSpecParams, Paganation<ProudctResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProudctRepositories _proudctRepository;



        public GetAllProudctQueryWithSpecParamsHandler(IMapper Mapper, IProudctRepositories proudctRepository)
        {
            _mapper = Mapper;
            _proudctRepository = proudctRepository;

        }
        public async Task<Paganation<ProudctResponseDto>> Handle(GetAllProudctQueryWithSpecParams request, CancellationToken cancellationToken)
        {


            var proudcts = await _proudctRepository.GetAllProudctsWithSpecParams(request.catalogSpecParams);
            var proudctResponseDto = _mapper.Map<Paganation<Proudct>, Paganation<ProudctResponseDto>>(proudcts);
            return proudctResponseDto;
        }
    }
}
