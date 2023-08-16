using System;
using System.Collections.Generic;
namespace WebApi.Domain.src.Entities
{
    public class CartItem: BaseEntity
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}