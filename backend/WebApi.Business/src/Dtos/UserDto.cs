using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Dtos
{
    public class UserReadDto 
    {
        public Guid Id{ get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public  string City { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        
    }
    
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public  string City { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

    }
    public class UserUpdateDto
    {
        
        public string Avatar { get; set; }
        public string Address { get; set; }
        public  string City { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

    }

    public class UserCredentialsDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}