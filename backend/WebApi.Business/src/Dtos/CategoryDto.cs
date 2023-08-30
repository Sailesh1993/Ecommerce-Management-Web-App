namespace WebApi.Business.src.Dtos
{
    public class CategoryReadDto
    {
        public string Name { get; set; }
    }

    public class CategoryCreateDto
    {
        public string? Name { get; set; }
    }

    public class CategoryUpdateDto
    {
        public string? Name { get; set; }
    }
}