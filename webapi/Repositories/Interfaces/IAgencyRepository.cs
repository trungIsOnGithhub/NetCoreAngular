using webapi.Models;

namespace webapi.Repositories
{
    public interface IAgencyRepository : IRepository<Agency>
    {
        Task<List<Agency>> GetAllByUserIdAsync(int userId);
    }
}