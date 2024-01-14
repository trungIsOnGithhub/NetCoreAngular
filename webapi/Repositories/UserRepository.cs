using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<bool> UserAlreadyExists(string userName)
        {
            return await dataContext.Users.AnyAsync(x => x.Username == userName);
        }

        public async Task<User> Authenticate(string userName, string plainTextPassword)
        {
            try
            {
                var user =  await dataContext.Users.FirstOrDefaultAsync(user => user.Username == userName);
            }
            catch (Exception e)
            {
                return null;
            }

            if (user == null)
                return null;

            if (!matchPasswordHash(plainTextPassword, user.Password, user.HashKey))
                return null;

            return user;
        }

        public void Register(string userName, string password)
        {
            byte[] passwordHash, hashKey;

            using (var hmac = new HMACSHA512())
            {
                hashKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            User user = new User {
                Username = userName;
                Password = passwordHash;
                HashKey = hashKey;
            };

            dataContext.Users.Add(user);
        }

        private bool matchPasswordHash(string plainTextPassword, byte[] password, byte[] hashKey)
        {
            using (var hmac = new HMACSHA512(hashKey))
            {
                var passwordHash = hmac.ComputeHash(
                    System.Text.Encoding.UTF8.GetBytes(plainTextPassword)
                );

                for (int i=0; i < passwordHash.Length; ++i)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }

                return true;
            }            
        }
    }
}