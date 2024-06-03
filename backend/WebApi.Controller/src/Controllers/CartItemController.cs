using Microsoft.AspNetCore.Authorization;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.Controller.src.Controllers
{
    [Authorize]
    public class CartItemController : BaseController<CartItem, CartItemReadDto, CartItemCreateDto, CartItemUpdateDto>
    {
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartItemService cartItemService) : base(cartItemService)
        {
            _cartItemService = cartItemService;
        }
    }
}