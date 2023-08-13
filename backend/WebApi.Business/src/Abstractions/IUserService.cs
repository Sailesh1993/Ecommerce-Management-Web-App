using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Abstractions
{
    public interface IUserService : IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        Task<UserReadDto> UpdatePassword(Guid id, string newPassword);
        // UserDto GetProfile(Guid id); --> only have this method in controller because logic is same as in service
        
    }
}