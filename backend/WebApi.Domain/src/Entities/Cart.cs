using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace WebApi.Domain.src.Entities
{
    public class Cart: BaseEntity
    {
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public User User{ get; set; }
        public bool IsActive { get; set; }
        public List<CartItem> CartItem { get; set; }
    }
}