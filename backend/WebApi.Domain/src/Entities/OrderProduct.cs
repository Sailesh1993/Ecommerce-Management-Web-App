namespace WebApi.Domain.src.Entities
{
    public class OrderProduct: BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}