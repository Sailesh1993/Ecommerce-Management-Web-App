using AutoMapper;
using Moq;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Business.src.Implementations;
using WebApi.Domain.src.Abstractions;


namespace WebApi.Testing.src.Business.Test
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepo> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepo>();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(
                _userRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateOne_ValidDto_Success()
        {
            //Arrange
            var createDto = new UserCreateDto
            {
                Username = "David22",
                Password = "david123",
                Email = "david@gmail.com",
                FirstName = "David",
                LastName = "Sharma",
                Avatar = "sharma222",
            };
        }
    }
}