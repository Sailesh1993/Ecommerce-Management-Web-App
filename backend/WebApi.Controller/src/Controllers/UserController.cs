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

        [HttpPost("password")]
        public async Task<ActionResult<UserReadDto>> UpdatePassword(
            Guid id, [FromBody] PasswordUpdateDto passwordUpdateDto
        )
        {
            try
            {
                var updatedUser = await _userService.UpdatePassword(id, passwordUpdateDto.Password);
                if(updatedUser == null)
                {
                    return NotFound($"User with Id {id} not found" );
                }
                var userReadDto = _mapper.Map<UserReadDto>(updatedUser);
                return Ok(userReadDto);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }
        
        [HttpPost("Admin")]
        public async Task<ActionResult<UserReadDto>> CreateAdmin([FromBody] UserCreateDto userCreateDro)
        {
            var createdObject = await _userService.CreateAdmin(userCreateDro);
            return CreatedAtAction(nameof(CreateAdmin), createdObject);
        }

        [AllowAnonymous]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {    return Ok(await _userService.GetAll(queryOptions));
             
        }
        
        [AllowAnonymous]
        public override async Task<ActionResult<UserReadDto>> GetOneById([FromRoute] Guid id)
        {
            return Ok(await _userService.GetOneById(id));
        }
    }
}