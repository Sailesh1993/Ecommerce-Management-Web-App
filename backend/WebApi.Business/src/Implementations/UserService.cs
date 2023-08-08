using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async Task<UserReadDto> UpdatePassword(string id, string newPassword)
        {
            var foundUser = await _userRepo.GetOneById(id);
            if (foundUser == null)
            {
                throw new Exception("User not found");
            }
            return _mapper.Map<UserReadDto>(await _userRepo.UpdatePassword(foundUser, newPassword));
        }
    }
}