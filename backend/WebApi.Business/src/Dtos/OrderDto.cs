using AutoMapper.Configuration.Annotations;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Dtos
{
    public class OrderReadDto
    {
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderProductReadDto> OrderProducts { get; set; }
    }

    public class OrderCreateDTo
    {
        public string ShippingAddress { get; set; }
        public Guid UserId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public class OrderUpdateDto
    {
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}