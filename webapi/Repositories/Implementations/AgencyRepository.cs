using Microsoft.EntityFrameworkCore;

using webapi.Models;
using webapi.Persistence;
using webapi.Repositories.Interfaces;

namespace webapi.Repositories.Implementations
{
    public class AgencyRepository : BaseRepository<Agency>, IAgencyRepository
    {
        private readonly DataContext _context;

        public AgencyRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Agency> GetByIdAsync(int id)
        {
            return await _context.Agencies.Include(x => x.Plans).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Agency>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Agencies.Where(x => x.OrganizationId == userId).ToListAsync();
        }
    }
}