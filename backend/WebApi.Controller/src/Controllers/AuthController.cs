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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> VerifyCredentials([FromBody] UserCredentialsDto credentials)
        {
            var authResponse = await _authService.VerifyCredentials(credentials);
            return Ok (authResponse);
        }
    }
}