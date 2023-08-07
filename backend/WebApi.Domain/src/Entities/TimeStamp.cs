namespace WebApi.Domain.src.Entities
{
    public class TimeStamp: BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
   }
}