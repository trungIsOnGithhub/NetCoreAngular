using Microsoft.EntityFrameworkCore;

using webapi.Models;
using webapi.Persistence;
using webapi.Repositories.Interfaces;

namespace webapi.Repositories.Implementations
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetPaginatedAsync(int count, int skip)
        {
            return await _context.Set<T>().Skip(skip).Take(count).ToListAsync();
        }

        public virtual async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            T entity = await _context.Set<T>().FindAsync(id);

            if (entity is null)
                return;

            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}