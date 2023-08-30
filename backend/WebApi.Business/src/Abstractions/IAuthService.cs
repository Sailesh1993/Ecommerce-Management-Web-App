using WebApi.Business.src.Dtos;

namespace WebApi.Business.src.Abstractions
{
    public interface IAuthService
    {
        Task<string> VerifyCredentials(UserCredentialsDto credentials);
    }
}