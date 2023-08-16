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

        // [AllowAnonymous]
        // public override async Task<ActionResult<IList<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        // {   var userlist = await base.GetAll(queryOptions);
        //     return Ok(userlist);
        // }
        
        [AllowAnonymous]
        public override async Task<ActionResult<UserReadDto>> GetOneById([FromRoute] Guid id)
        {
            return Ok(await base.GetOneById(id));
        }
    }
}