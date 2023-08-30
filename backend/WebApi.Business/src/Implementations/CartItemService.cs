using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class CartItemService : BaseService<CartItem, CartItemReadDto, CartItemCreateDto, CartItemUpdateDto>, ICartItemService
    {
        public CartItemService(ICartItemRepo cartItemRepo, IMapper mapper) : base(cartItemRepo, mapper)
        {
        }
    }
}