using webapi.Models;

namespace webapi.Repositories.Interfaces
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Task<Organization> GetByUserId(string userId);

        Task<int> IterateContractNumber(int organizationId);
    }
}