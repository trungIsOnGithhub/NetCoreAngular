using webapi.Models;

namespace webapi.Repositories.Interfaces
{
    public interface IPlanRepository : IRepository<Plan>
    {
        Task<Plan> GetByHotelNameAndLocation(string hotelName, string location, int agencyId, int userId);
        Task<List<Plan>> GetAllByAgencyAsync(int agencyId, int userId);
    }
}