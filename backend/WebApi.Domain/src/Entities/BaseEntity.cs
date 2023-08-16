using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain.src.Entities
{
    public class BaseEntity
    {
        [Key]
       public Guid Id { get; set; }
    }
}