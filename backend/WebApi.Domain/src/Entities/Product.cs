using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.src.Entities
{
    public class Product: BaseEntity
    {
        public string? Title { get; set; }
        public List <string>? Images { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }   

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        
    }
}