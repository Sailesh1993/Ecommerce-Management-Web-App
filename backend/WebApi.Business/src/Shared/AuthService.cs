using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Common;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Shared
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _config;

        public AuthService(IUserRepo userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<string> VerifyCredentials(UserCredentialsDto credentials)
        {
            var foundUserByEmail =
                await _userRepo.FindOneByEmail(credentials.Email)
                ?? throw new Exception("Email not found");
            var isAuthenticated = PasswordService.VerifyPassword(
                credentials.Password,
                foundUserByEmail.Password,
                foundUserByEmail.Salt
            );
            if (!isAuthenticated)
            {
                throw new Exception("Password do not match");
            }
            return await GenerateToken(foundUserByEmail);
        }

        public async Task<string> GenerateToken(User user)
        {
            string secretKey = _config["Jwt:Key"] ?? "backup-my-private-secure-from-everything-SecretKey";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Uri, user.Avatar)  
            };
            string secretIssuer = _config["Jwt:Issuer"] ?? "backup-my-private-issuer-from-everything-SecretIssuer";

            var token = new JwtSecurityToken(
                issuer: secretIssuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> AbstractClaims(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            Console.WriteLine(jsonToken);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            var claims =
                tokenS.Claims ?? throw CustomErrorHandler.NotFoundException("Token not valid.");
            var user = new User();

            try
            {
                user.Email = claims.First(claim => claim.Type == ClaimTypes.Email).Value;
                user.Role = (Role)
                    Enum.Parse(
                        typeof(Role),
                        claims.First(claim => claim.Type == ClaimTypes.Role).Value
                    );
                user.FirstName = claims.First(claim => claim.Type == ClaimTypes.Name).Value;
                user.Id = Guid.Parse(
                    claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value
                );
                user.LastName = claims.First(claim => claim.Type == ClaimTypes.Surname).Value;
                user.Avatar = claims.First(claim => claim.Type == ClaimTypes.Uri).Value;
            }
            catch (Exception ex)
            {
                // If there is an issue with claims extraction, handle it as a custom error
                throw new CustomErrorHandler(500, "Error extracting claims from the token.");
            }

            return user;
        }
    }
}
