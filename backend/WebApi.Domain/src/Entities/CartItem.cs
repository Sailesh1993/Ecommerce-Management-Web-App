using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.src.Entities
{
    public class CartItem : BaseEntity
    {
       [ForeignKey(nameof(Cart))] // Foreign key attribute
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public bool IsActive { get; set; }        
        public int Quantity { get; set; }

        
        
    }
}
