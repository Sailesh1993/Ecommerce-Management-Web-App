using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Dtos
{
    public class OrderReadDto
    {
        public string ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }

    public class OrderCreateDTo
    {
        public string ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Guid UserId { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }

    public class OrderUpdateDto
    {
        public string ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}