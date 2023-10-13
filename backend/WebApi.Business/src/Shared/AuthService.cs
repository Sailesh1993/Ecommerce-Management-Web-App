using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Shared
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        public AuthService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<AuthResponse> VerifyCredentials(UserCredentialsDto credentials)
        {
            var foundUserByEmail = await _userRepo.FindOneByEmail(credentials.Email) ?? throw new Exception("Email not found");
            var isAuthenticated = PasswordService.VerifyPassword(credentials.Password, foundUserByEmail.Password, foundUserByEmail.Salt);
            if(!isAuthenticated)
            {
                throw new Exception("Credentials do not match");
            }
            string accessToken = GenerateToken(foundUserByEmail);
            return new AuthResponse
            {
                AccessToken = accessToken
            };
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-secret-key-is-my-goal-to-secure-everything"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor{
                Issuer = "ecommerce-backend",
                Expires = DateTime.Now.AddMinutes(10),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);
            return tokenValue;
        }

        /* private string RefreshAccessToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-secret-key-is-my-goal-to-secure-everything"));

            
        } */

        /* public async Task<string> RefreshToken(string refreshToken)
        {
            return await GenerateToken(refreshToken);
        } */
    }
}