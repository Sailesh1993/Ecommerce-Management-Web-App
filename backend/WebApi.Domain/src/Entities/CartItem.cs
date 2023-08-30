using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.src.Entities
{
    public class CartItem : BaseEntity
    {
       [ForeignKey(nameof(Cart))] 
        public Guid CartId { get; set; } // Foreign key attribute
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public bool IsActive { get; set; }        
        public int Quantity { get; set; }
        
        public Product Product { get; set; }
        public Cart Cart { get; set; }

        
        
    }
}
