using Application.DTO;
using Application.DTO.UpdateEntity;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UpdateProductDto, Product>()
                .ForMember(c => c.QuantityInStock, o => o.Ignore());
            CreateMap<Product, ProductDto>()
                .ForMember(c => c.QuantityInStock, o => o.Ignore());
            CreateMap<ProductDto, Product>()
                .ForMember(c => c.QuantityInStock, o => o.Ignore());

            CreateMap<UpdateOrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<UpdateOrderItemDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>().ForMember(
                c => c.Quantity,
                o => o.MapFrom(s => ProductQuantity.Create(s.Quantity)));

            CreateMap<UpdateFirstLevelIconSectionDto, FirstLevelIconSection>();
            CreateMap<FirstLevelIconSectionDto, FirstLevelIconSection>();
            CreateMap<FirstLevelIconSection, FirstLevelIconSectionDto>();

            CreateMap<UpdateFirstLevelImageSectionDto, FirstLevelImageSection>();
            CreateMap<FirstLevelImageSectionDto, FirstLevelImageSection>();
            CreateMap<FirstLevelImageSection, FirstLevelImageSectionDto>();

            CreateMap<UpdateSecondLevelSectionDto, SecondLevelSection>();
            CreateMap<SecondLevelSectionDto, SecondLevelSection>();
            CreateMap<SecondLevelSection, SecondLevelSectionDto>();
        }
    }
}
