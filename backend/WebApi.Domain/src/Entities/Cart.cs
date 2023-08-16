using System;
using System.Collections.Generic;
using System.Linq;
namespace WebApi.Domain.src.Entities
{
    public class Cart: TimeStamp
    {
        public Guid UserId { get; set; }
        public Decimal TotalAmount { get; set; }
        public CartItem CartItem { get; set; }
    }
}