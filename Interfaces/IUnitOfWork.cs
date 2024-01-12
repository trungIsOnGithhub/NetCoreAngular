using System.Threading.Tasks;

namespace webapi.Interfaces
{
    public interface IUnitOfWork
    {
        // contains all repository for any transaction
        ICityRepository CityRepository { get; }

        IUserRepository UserRepository { get; }

        IPropertyRepository PropertyRepository { get; }

        Task<bool> SaveAsync();
    }
}