using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;
using WebApi.Domain.src.Shared;

namespace WebApi.Controller.src.Controllers
{
    public class UserController: BaseController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;   
        }

        [Authorize]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            return Ok(await base.GetAll(queryOptions));
        }
        
        [AllowAnonymous]
        public override async Task<ActionResult<UserReadDto>> GetOneById([FromRoute] Guid id)
        {
            return Ok(await base.GetOneById(id));
        }
    }
}