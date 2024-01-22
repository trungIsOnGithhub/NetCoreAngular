using webapi.Models;

namespace webapi.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetPaginatedAsync(int count, int skip);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteByIdAsync(int id);
    }
}