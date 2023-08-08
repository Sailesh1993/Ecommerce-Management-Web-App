namespace WebApi.Domain.src.Entities
{
    public class Order: TimeStamp
    {
        public OrderStatus OrderStatus { get; set; }
        public User User { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped
        
    }
}