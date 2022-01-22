using Application.DTO;
using Application.DTO.UpdateEntity;
using Application.DTO.User;
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

            CreateMap<UpdateOrderDto, Order>()
                .ForMember(c => c.Items, o => o.Ignore());
            CreateMap<Order, OrderDto>()
                .ForMember(c => c.Items, o => o.Ignore());
            CreateMap<OrderDto, Order>()
                .ForMember(c => c.Items, o => o.Ignore());

            CreateMap<UpdateOrderItemDto, OrderItem>()
                .ForMember(c => c.Quantity, o => o.Ignore());
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(c => c.Quantity, o => o.Ignore());
            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(c => c.Quantity, o => o.Ignore());

            CreateMap<UserRegistrationDto, ApplicationUser>()
                .ForMember(c => c.UserName, o => o.MapFrom(s => s.DisplayName));
            CreateMap<UserLoginDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>()
                .ForMember(c => c.UserName, o => o.MapFrom(s => s.DisplayName));

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
