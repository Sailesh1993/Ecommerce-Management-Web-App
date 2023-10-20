using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;

namespace WebApi.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> VerifyCredentials(
            [FromBody] UserCredentialsDto credentials
        )
        {
            var authResponse = await _authService.VerifyCredentials(credentials);
            return Ok(authResponse);
        }

        [Authorize]
        [HttpGet("profile")]
         public async Task<ActionResult<UserReadDto>> UserAuthorization()
        {
            var token = HttpContext.Request.Headers.TryGetValue("Authorization", out var accessToken);
            if(!token)
            {
                Console.WriteLine("Authorization token not found.");
                return NotFound("Authorization token not found.");
            }
            return Ok(await _authService.AbstractClaims(accessToken.ToString().Replace("Bearer ", "")));
        }
    }
}
