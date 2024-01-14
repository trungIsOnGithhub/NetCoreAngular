using System.Threading.Tasks;
using webapi.Repository;
using webapi.Interfaces;

namespace webapi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public ICityRepository CityRepository => 
            new CityRepository(dataContext);

        public IUserRepository UserRepository =>         
            new UserRepository(dataContext);

        public IPropertyRepository PropertyRepository => 
            new PropertyRepository(dataContext);

        public async Task<bool> SaveAsync()
        {
           return await dataContext.SaveChangesAsync() > 0;
        }
    }
}