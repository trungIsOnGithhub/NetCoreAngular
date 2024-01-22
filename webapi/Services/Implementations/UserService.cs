using Microsoft.AspNetCore.Identity;

using webapi.Repositories;
using webapi.Models;
using webapi.Dtos;
using webapi.Mappers;

namespace webapi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrganizationRepository _organizationRepository;

        public UserService(UserManager<User> userManager, IOrganizationRepository organizationRepository)
        {
            _userManager = userManager;
            _organizationRepository = organizationRepository;
        }

        public async Task<UserDetailsDto> GetDetails(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return null;

            Organization organization = await _organizationRepository.GetByUserId(user.Id);

            UserDetailsDto dto = user.ToUserDetailsDto();

            dto.BankAccountNumber = organization.BankAccountNumber;
            dto.DisplayName = organization.Name;
            dto.Address = organization.Address ?? "/";
            dto.Website = organization.Website ?? "/";
            dto.ImageLink = organization.ImagePath;

            return dto;
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return false;
            return true;
        }

        public async Task<bool> IsUserTaken(string username)
        {
            User user = await _userManager.FindByNameAsync(username);
            if (user is null)
                return false;
            return true;
        }

        public async Task UpdateUserInfo(string userId, UserUpdateDto dto)
        {
            User user = await _userManager.FindByIdAsync(userId)
                                    ?? throw new Exception("No user");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.PhoneNumber = dto.PhoneNumber;

            await _userManager.UpdateAsync(user);
        }
    }
}