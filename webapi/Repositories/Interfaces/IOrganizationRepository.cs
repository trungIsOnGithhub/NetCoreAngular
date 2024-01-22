using webapi.Models;

namespace webapi.Repositories
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Task<Organization> GetByUserId(string userId);

        Task<int> IterateContractNumber(int organizationId);
    }
}