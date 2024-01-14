using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using webapi.Data;
using webapi.Models;
using webapi.Interfaces;

// should we 
namespace webapi.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dataContext;

        public CityRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddCity(City city)
        {
            dataContext.Cities.Add(city);             
        }

        public void DeleteCity(int id)
        {
            var city = dataContext.Cities.Find(id);
            dataContext.Cities.Remove(city);
        }

        public async Task<City> FindCity(int id)
        {
            return await dataContext.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dataContext.Cities.ToListAsync();
        }
    }
}