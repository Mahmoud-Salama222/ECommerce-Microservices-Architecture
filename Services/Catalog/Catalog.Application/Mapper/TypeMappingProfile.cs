using AutoMapper;
using Catalog.Application.Response;
using Catalog.Core.Entities;

namespace Catalog.Application.Mapper
{
    public class TypeMappingProfile : Profile
    {

        public TypeMappingProfile()
        {
            CreateMap<ProudctType, TypeResponseDto>().ReverseMap();
        }
    }
}
