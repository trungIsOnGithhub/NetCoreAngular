using webapi.Models;
using System.Threading.Tasks;

namespace webapi.Interfaces
{
    public interface IUserRepository
    {
         Task<User> AuthenticateAsync(string userName, string password);

         void RegisterAsync(string userName, string password); 

         Task<bool> CheckUserExistsAsync(string userName);
    }
}