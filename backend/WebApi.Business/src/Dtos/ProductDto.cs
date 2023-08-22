using AutoMapper.Configuration.Annotations;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Dtos
{
    public class ProductReadDto
    {
        public string Title { get; set; }
        public List <string> Images { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }

    public class ProductCreateDto
    {
        public string Title { get; set; }
        public List <string> Images { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class ProductUpdateDto
    {
        public string Title { get; set; }
        public List <string> Images { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}