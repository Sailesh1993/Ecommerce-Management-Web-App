using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.src.Entities
{
    public class CartItem : BaseEntity
    {
        [Required]
        public Guid CartId { get; set; }

        [ForeignKey("CartId")] // Foreign key attribute
        public virtual Cart Cart { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
