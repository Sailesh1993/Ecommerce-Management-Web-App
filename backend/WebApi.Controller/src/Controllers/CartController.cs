using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.Controller.src.Controllers
{
    [Authorize]
    public class CartController : BaseController<Cart, CartReadDto, CartCreateDto, CartUpdateDto>
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
            : base(cartService)
        {
            _cartService = cartService;
        }
    
        public override async Task<ActionResult<CartReadDto>> CreateOne(
            [FromBody] CartCreateDto createDto
        )
        {
            if (createDto.CartItem.Quantity > 0)
            {
                var createdProduct = await _cartService.AddToCart(createDto);
                return CreatedAtAction(nameof(CreateOne), createdProduct);
            }
            else
            {
                return NotFound("Quantity cannot be zero");
            }
        }

        [HttpGet("{userId:guid}")]
        public override async Task<ActionResult<CartReadDto>> GetOneById( Guid userId)
        {
            var cartDetails = await _cartService.GetUserCartDetails(userId);
            if (cartDetails == null)
            {
                return Ok(null);
            }
            return Ok(cartDetails);
        }

        [HttpDelete("{id:Guid},{userId:Guid}")]
        public async Task<ActionResult<CartReadDto>> DeleteOneById([FromRoute] Guid id, Guid userId)
        {
            var cartDetails = await _cartService.RemoveProductFromCart(id, userId);
            if (cartDetails == null)
            {
                return Ok(null);
            }
            return Ok(cartDetails);
        }
    }
}
