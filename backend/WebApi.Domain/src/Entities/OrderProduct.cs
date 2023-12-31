using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.src.Entities
{
    public class OrderProduct : BaseEntity
    {
        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; } 
        [ForeignKey("ProductId")] 
        public Guid ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        
        public Product Product { get; set; }
        public Order Order { get; set; } // navigation
    }
}
