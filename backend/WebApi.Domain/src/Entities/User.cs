using System.Text.Json.Serialization;

namespace WebApi.Domain.src.Entities
{
    public class User: TimeStamp
    {
        public string Username { get; set; }
        public string Password { get; set;}
        public byte[] Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }

        /* public UserContactDetails UserContactDetails { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; } */
        
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
     public enum Role
    {
        Admin,
        User
    }
}

