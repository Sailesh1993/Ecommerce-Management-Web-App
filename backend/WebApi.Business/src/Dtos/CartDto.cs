using AutoMapper.Configuration.Annotations;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Dtos
{
    public class CartReadDto
    {
        public Decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CartItem>? CartItem { get; set; }
    }

    public class CartCreateDto
    {
        public Decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CartItem>? CartItem { get; set; }
        
    }

    public class CartUpdateDto
    {
        public Decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }
        
    }

    
}