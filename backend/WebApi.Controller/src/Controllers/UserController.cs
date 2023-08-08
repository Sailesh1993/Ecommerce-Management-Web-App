using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.Controller.src.Controllers
{
    public class UserController: BaseController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;   
        }
    }
}