using System;
using System.Collections.Generic;
using System.Linq;
namespace WebApi.Domain.src.Entities
{
    public class Cart: TimeStamp
    {
        public Guid UserId { get; set; }
        public Decimal Total { get; set; }
        public DateTime ExpiresAt { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}