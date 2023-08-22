using AutoMapper;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.WebApi.src.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();

            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryReadDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<OrderCreateDTo, Order>();

            CreateMap<OrderProduct, OrderProductReadDto>();
            CreateMap<OrderProductUpdateDto, OrderProduct>();
            CreateMap<OrderProductCreateDto, OrderProduct>();

            CreateMap<Cart, CartReadDto>();
            CreateMap<CartUpdateDto, Cart>();
            CreateMap<CartCreateDto, Cart>();
            CreateMap<CartCreateDto, CartUpdateDto>();
            CreateMap<CartUpdateDto, CartCreateDto>();
            CreateMap<CartReadDto, Cart>();
            CreateMap<CartReadDto, Product>();
            CreateMap<Product, CartReadDto>();
            
            CreateMap<CartItem, CartItemReadDto>();
            CreateMap<CartUpdateDto, Cart>();
            CreateMap<CartItemCreateDto, CartItem>();
            CreateMap<CartItemCreateDto, List<CartItem>>();
            // CreateMap<List<CartItemReadDto>, List<CartItem>>();
            // CreateMap<List<CartItem>, List<CartItemReadDto> >();
            
        }
    }
}
