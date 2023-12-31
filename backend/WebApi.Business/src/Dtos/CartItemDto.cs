namespace WebApi.Business.src.Dtos
{
    public class CartItemReadDto
    {
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }

    }

    public class CartItemCreateDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

    }

    public class CartItemUpdateDto
    {
        public int Quantity { get; set; }
    }
}