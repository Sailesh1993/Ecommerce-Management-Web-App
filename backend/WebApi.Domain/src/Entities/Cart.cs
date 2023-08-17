using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace WebApi.Domain.src.Entities
{
    public class Cart: TimeStamp
    {
        public Guid UserId { get; set; }
        public Decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CartItem> CartItem { get; set; }
    }
}