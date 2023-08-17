using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.src.Entities
{
    public class OrderProduct : BaseEntity
    {
        [Required]
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")] // Foreign key attribute
        public virtual Order Order { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
