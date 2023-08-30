using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Dtos
{
    public class CartReadDto
    {
        public Decimal? TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public List<CartItemReadDto> CartItem { get; set; }

    }

    public class CartCreateDto
    {
        public CartItemCreateDto CartItem { get; set; }
        public Guid? UserId { get; set; }
    }

    public class CartUpdateDto
    {
        public Guid CartId{ get; set; }
        public CartItem CartItem { get; set;}
    }

    
}