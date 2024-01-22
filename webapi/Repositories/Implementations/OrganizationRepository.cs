using Microsoft.EntityFrameworkCore;

using webapi.Models;
using webapi.Persistence;
using webapi.Repositories.Interfaces;

namespace webapi.Repositories.Implementations
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        private readonly DataContext _context;

        public OrganizationRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Organization> GetByUserId(string userId)
        {
            return await _context.Users.Include(x => x.Organization).Where(x => x.Id == userId).Select(x => x.Organization).FirstOrDefaultAsync();
        }

        public async Task<int> IterateContractNumber(int organizationId)
        {
            Organization org = await _context.Organizations.FindAsync(organizationId);

            if (org is null)
                return 0;

            int currentIterator = org.ContractIterator++;
            _context.Organizations.Update(org);

            await _context.SaveChangesAsync();

            return currentIterator;
        }
    }
}