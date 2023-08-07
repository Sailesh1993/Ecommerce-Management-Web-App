namespace WebApi.Domain.src.Entities
{
    public class User: BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }

        public UserContactDetails UserContactDetails { get; set; }
        
    }
}

public enum Role
{
    Admin,
    User
}