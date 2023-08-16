namespace WebApi.Domain.src.Entities
{
    public class Order: TimeStamp
    {
        public Guid UserId { get; set; }
        public string ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Canceled
        
    }
}
