using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Dtos
{
    public class UserReadDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }

        public UserContactDetails UserContactDetails { get; set; }
    }
    
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        public UserContactDetails UserContactDetails { get; set; }
    }
    public class UserUpdateDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public UserContactDetails UserContactDetails { get; set; }
    }
}