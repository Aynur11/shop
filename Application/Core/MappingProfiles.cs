using Application.DTO;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, Product>();
            CreateMap<Order, OrderDto>();
            CreateMap<FirstLevelIconSection, FirstLevelIconSectionDto>();
            CreateMap<FirstLevelImageSection, FirstLevelImageSectionDto>();
            CreateMap<SecondLevelSection, SecondLevelSectionDto>();
        }
    }
}
