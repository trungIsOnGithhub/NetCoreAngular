using webapi.Dtos;

namespace webapi.Services
{
    public interface IUserService
    {
        Task<UserDetailsDto> GetDetails(string userId);

        Task UpdateUserInfo(string userId, UserUpdateDto dto);

        Task<bool> IsEmailTaken(string email);
        Task<bool> IsUserTaken(string username);
    }
}