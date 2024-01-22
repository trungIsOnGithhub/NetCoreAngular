using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using TravelAgency.Persistence;
using webapi.Services;
using webapi.Models;
using webapi.Enums;
using webapi.Dtos;

namespace webapi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IOrganizationRepository _organizationRepository;

        public AuthService(UserManager<User> userManager,
                IConfiguration configuration, IOrganizationRepository organizationRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _organizationRepository = organizationRepository;
        }

        public async Task RegisterUser(UserRegisterDto dto)
        {
            User user = new User {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.Username,
                Email = dto.Email,
                Role = Role.User,
                RegisterDate = DateTime.Now
            };

            user.Organization = new Organization {
                Name = dto.DisplayName,
                Email = dto.Email,
                ContractIterator = 1,
                InvoiceIterator = 1,
                OwnerId = user.Id,
                BankAccountNumber = dto.BankAccountNumber,
            };

            await _userManager.CreateAsync(user, dto.Password);
        }

        public async Task<UserTokenDto> Login(UserLoginDto dto)
        {
            User user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null)
            {
                return null;
            }
            bool passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
            {
                return null;
            }
            var organizaion = await _organizationRepository.GetByUserId(user.Id);
            return new UserTokenDto
            {
                Id = user.Id,
                OrganizationId = organizaion.Id,
                Username = user.UserName,
                Email = user.Email,
                Address = organizaion.Address ?? string.Empty,
                DisplayName = organizaion.Name ?? string.Empty,
                BankAccountNumber = organizaion.BankAccountNumber ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = organizaion.ImagePath,
                Role = user.Role
            };
        }

        public async Task<UserTokenDto> CheckLastToken(string username, string lastToken, string newToken)
        {
            User user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return null;
            }
            if(!user.TokenExpireDate.HasValue)
            {
                return null;
            }
            if(user.LastToken != lastToken)
            {
                return null;
            }
            if(DateTime.Now > user.TokenExpireDate.Value)
            {
                return null;
            }
            user.LastToken = newToken;
            user.TokenExpireDate = DateTime.Now.AddDays(int.Parse(_configuration["Jwt:RefreshExpireTime"]));
            var organization = await _organizationRepository.GetByUserId(user.Id);

            await _userManager.UpdateAsync(user);

            return new UserTokenDto
            {
                Id = user.Id,
                OrganizationId = organization.Id,
                Username = user.UserName,
                Email = user.Email,
                Address = organization.Address ?? string.Empty,
                DisplayName = organization.Name ?? string.Empty,
                BankAccountNumber = organization.BankAccountNumber ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = organization.ImagePath,
                Role = user.Role
            };
        }

        public async Task SaveToken(string userId, string token)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return;

            user.LastToken = token;
            user.TokenExpireDate = DateTime.Now.AddDays(int.Parse(_configuration["Jwt:RefreshExpireTime"]));
            await _userManager.UpdateAsync(user);
        }
    }
}