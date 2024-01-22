using Microsoft.EntityFrameworkCore;

using webapi.Models;
using webapi.Persistence;
using webapi.Repositories.Interfaces;

namespace webapi.Repositories.Implementations
{
    public class PlanRepository : BaseRepository<Plan>, IPlanRepository
    {
        private readonly DataContext _context;

        public PlanRepository(DataContext context): base(context) 
        {
            _context = context;
        }

        public async Task<List<Plan>> GetAllByAgencyAsync(int agencyId, int userId)
        {
            return await _context.Plans.Include(e => e.Agency).Include(e => e.AvailableDates)
                                    .Where(e => e.AgencyId == agencyId
                                                && e.Agency.OrganizationId == userId)
                                    .ToListAsync();
        }

        public async Task<Plan> GetByHotelNameAndLocation(string hotelName, string location, int agencyId, int userId)
        {
            return await _context.Plans
                .Include(p => p.Agency)
                .Where(p => p.HotelName.ToLower() == hotelName.ToLower() 
                            && p.Location.ToLower() == location.ToLower() 
                            && p.AgencyId == agencyId
                            && p.Agency.OrganizationId == userId)
                .FirstOrDefaultAsync();
        }

        public override async Task<Plan> GetByIdAsync(int id)
        {
            return await _context.Plans.Include(e => e.AvailableDates).Include(e => e.Agency).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}