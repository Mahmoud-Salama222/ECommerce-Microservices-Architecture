using AutoMapper;
using Catalog.Application.Response;
using Catalog.Core.Entities;

namespace Catalog.Application.Mapper
{
    public class BrandMappingProfile : Profile
    {

        public BrandMappingProfile()
        {
            CreateMap<ProudctBrand, BrandResponseDto>().ReverseMap();
        }
    }
}
