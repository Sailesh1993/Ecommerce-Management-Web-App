using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserController(IUserService baseService, IMapper mapper) : base(baseService)
        {
            _userService = baseService;   
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("password")]
        public async Task<ActionResult<UserReadDto>> UpdatePassword( [FromQuery]
            Guid userId, [FromBody] PasswordUpdateDto passwordUpdateDto
        )
        {
            try
            {
                var updateResult = await _userService.UpdatePassword(userId, passwordUpdateDto.Password);
                if(updateResult == null)
                {
                    return NotFound($"User with Id {userId} not found" );
                }
                var updatedUser = _mapper.Map<UserReadDto>(updateResult);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("admin")]
        public async Task<ActionResult<UserReadDto>> CreateAdmin([FromBody] UserCreateDto userCreateDto)
        {
            var createdObject = await _userService.CreateAdmin(userCreateDto);
            return CreatedAtAction(nameof(CreateAdmin), createdObject);
        }

        [Authorize]
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid Id)
        {
            return await base.DeleteOneById(Id);
        }

        [Authorize]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {    return Ok(await _userService.GetAll(queryOptions));
             
        }
        
        [Authorize]
        public override async Task<ActionResult<UserReadDto>> GetOneById([FromRoute] Guid id)
        {
            return Ok(await _userService.GetOneById(id));
        }
    }
}