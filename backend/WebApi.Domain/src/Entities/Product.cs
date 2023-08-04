namespace WebApi.Domain.src.Entities
{
    public class Product: BaseEntityWithId
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Inventory { get; set; }
        
    }
}