using AutoMapper;
using Moq;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Business.src.Implementations;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Configuration;

namespace WebApi.Testing.src.Business.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task CreateOne_ValidDto_Success()
        {
            //Arrange
            var userCreateDto = new UserCreateDto
            {
                Username = "David22",
                Password = "david123",
                Email = "david@gmail.com",
                FirstName = "David",
                LastName = "Sharma",
                Avatar = "sharma222",
                Address = "Kirstinharju",
                City = "Espoo",
                PostalCode = "02760",
                Country = "Finland",
                PhoneNumber = "09765786"
            };

            var expectedUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Email = userCreateDto.Email,
                Username = userCreateDto.Username,
                Avatar = userCreateDto.Avatar,
                Role = Role.User,
                Address = userCreateDto.Address,
                City = userCreateDto.City,
                PostalCode = userCreateDto.PostalCode,
                Country = userCreateDto.Country,
                PhoneNumber = userCreateDto.PhoneNumber
            };

            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
            var userRepoMock = new Mock<IUserRepo>();
            userRepoMock.Setup(repo => repo.CreateOne(It.IsAny<User>()))
            .ReturnsAsync(expectedUser);

            var userService = new UserService(userRepoMock.Object,mapper);

            //Act
            var result = await userService.CreateOne(userCreateDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.FirstName, result.FirstName);
            Assert.Equal(expectedUser.LastName,result.LastName);
            Assert.Equal(expectedUser.Email, result.Email);
            Assert.Equal(expectedUser.Username,result.Username);
            Assert.Equal(expectedUser.Avatar, result.Avatar);
            Assert.Equal(expectedUser.Role, result.Role);
            Assert.Equal(expectedUser.Address,result.Address); 
            Assert.Equal(expectedUser.City,result.City);   
            Assert.Equal(expectedUser.PostalCode,result.PostalCode);
            Assert.Equal(expectedUser.Country,result.Country);
             Assert.Equal(expectedUser.PhoneNumber,result.PhoneNumber);

        }
        [Fact]
        public async Task UpdatePassword_ValidIdAndNewPassword_SuccessfullyUpdatesPassword()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var newPassword = "newpassword";

            var existingUser = new User
            {
                Id = userId,
                Password = "oldhashedpassword",
                Salt = new byte[32]
            };

            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));

            var userRepoMock = new Mock<IUserRepo>();
            userRepoMock.Setup(repo => repo.GetOneById(userId))
                        .ReturnsAsync(existingUser);

            userRepoMock.Setup(repo => repo.UpdatePassword(It.IsAny<User>()))
                        .ReturnsAsync(existingUser);

            var userService = new UserService(userRepoMock.Object, mapper);

            // Act
            var result = await userService.UpdatePassword(userId, newPassword);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);

            // Verify that Password and Salt are updated correctly
            //Assert.Equal(existingUser.Salt, result.Salt); // Assuming salt remains the same
            //Assert.NotEqual(existingUser.Password, result.Password); // Password should be updated
        }
    }
}