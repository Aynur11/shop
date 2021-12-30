using Application.DTO;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<FirstLevelIconSection, FirstLevelIconSectionDto>();
            CreateMap<FirstLevelIconSectionDto, FirstLevelIconSection>()
                .ForMember(dest => dest.FirstLevelImageSections, opt => opt.Ignore());

            CreateMap<FirstLevelImageSection, FirstLevelImageSectionDto>();
            CreateMap<FirstLevelImageSectionDto, FirstLevelImageSection>();

            CreateMap<SecondLevelSection, SecondLevelSectionDto>();
            CreateMap<SecondLevelSectionDto, SecondLevelSection>();
        }
    }
}
