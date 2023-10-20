using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;


namespace WebApi.Business.src.Abstractions
{
    public interface IAuthService
    {
        Task<string> VerifyCredentials(UserCredentialsDto credentials);
        Task<User> AbstractClaims(string token);
    }
}