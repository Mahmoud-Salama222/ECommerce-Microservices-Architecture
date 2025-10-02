using AutoMapper;
using Catalog.Application.commends;
using Catalog.Application.Queries;
using Catalog.Application.Response;
using Catalog.Core.Entities;
using Catalog.Core.Paganation;
using Catalog.Core.Spec;

namespace Catalog.Application.Mapper
{
    public class ProudctMappingProfile : Profile
    {

        public ProudctMappingProfile()
        {
            CreateMap<Proudct, ProudctResponseDto>().ReverseMap();

            CreateMap<CreateProudctCommend, Proudct>().ReverseMap();
            CreateMap<GetAllProudctQueryWithSpecParams, CatalogSpecParams>().ReverseMap();
            CreateMap<Paganation<ProudctResponseDto>, Paganation<Proudct>>().ReverseMap();



            CreateMap<UpdateProudctCommend, Proudct>().ReverseMap();


        }
    }
}
