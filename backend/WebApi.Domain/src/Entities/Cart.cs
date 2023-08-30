using System.ComponentModel.DataAnnotations.Schema;

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