using webapi.Models;

namespace webapi.Repositories.Interfaces
{
    public interface IAgencyRepository : IRepository<Agency>
    {
        Task<List<Agency>> GetAllByUserIdAsync(int userId);
    }
}