using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Domain.src.Entities
{
    public class Order: BaseEntity
    {
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public  User User{ get; set; }

        public string? ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Canceled
        
    }
}
