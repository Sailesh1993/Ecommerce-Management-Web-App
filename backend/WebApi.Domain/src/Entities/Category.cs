using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.src.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
    }
}