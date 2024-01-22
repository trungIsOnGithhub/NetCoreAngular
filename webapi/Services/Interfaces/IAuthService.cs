using webapi.Models;
using webapi.Dtos;

namespace webapi.Services
{
    public interface IAuthService
    {
        Task RegisterUser(UserRegisterDto dto);

        Task<UserTokenDto> Login(UserLoginDto dto);

        Task<UserTokenDto> CheckLastToken(string username, string lastToken, string newToken);

        Task SaveToken(string userId, string token);
    }
}