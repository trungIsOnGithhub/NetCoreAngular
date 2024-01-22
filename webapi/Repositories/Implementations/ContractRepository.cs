using webapi.Models;
using webapi.Context;
using webapi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webapi.Repositories.Implementations
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        private readonly DataContext _context;

        public ContractRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CountActiveAsync(int organizationId)
        {
            return await _context.Contracts.Where(e => e.OrganizationId == organizationId && x.IsArchived == false).CountAsync();
        }

        public async Task<List<Contract>> GetActiveByRangeAsync(int userId, DateTime start, DateTime end)
        {
            return await _context.Contracts
                .Include(e => e.Plan)
                .Where(e => e.OrganizationId == userId 
                    && !x.IsArchived 
                    && start <= x.EndDate 
                    && end >= x.StartDate).ToListAsync();
        }

        public async Task<List<Contract>> GetActiveByUserIdAsync(int userId)
        {
            return await _context.Contracts.Include(e => e.Plan).Where(e => e.OrganizationId == userId && !x.IsArchived).ToListAsync();
        }

        public Task<List<Contract>> GetActivePaginatedAsync(int organizationId, int skip, int take)
        {
            return _context.Contracts
                .Include(e => e.Plan)
                .Where(e => e.OrganizationId == organizationId && x.IsArchived == false)
                .Skip(skip)
                .Take(take)
                .OrderByDescending(e => e.Id)
                .ToListAsync();
        }

        public override async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contracts
                .Include(e => e.Passengers)
                .Include(e => e.Organization)
                .Include(e => e.Plan)
                .ThenInclude(e => e.Agency)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}