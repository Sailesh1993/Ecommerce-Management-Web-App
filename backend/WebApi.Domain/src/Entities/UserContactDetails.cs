namespace WebApi.Domain.src.Entities
{
    public class UserContactDetails: BaseEntity
    {   
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public  string City { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        

    }
}