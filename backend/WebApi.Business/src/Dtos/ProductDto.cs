using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Dtos
{
    public class ProductDto
    {
        public string Title { get; set; }
        public List <string> Images { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}