using WebApi.Business.src.Dtos;

namespace WebApi.Business.src.Abstractions
{
    public interface IAuthService
    {
        Task<AuthResponse> VerifyCredentials(UserCredentialsDto credentials);
        /* Task<string> RefreshToken(string refreshToken); */
    }
}