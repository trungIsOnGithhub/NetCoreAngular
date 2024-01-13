using webapi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace webapi.Interfaces
{
    public interface ICityRepository
    {
         Task<IEnumerable<City>> GetCitiesAsync();

         void AddCityAsync(City city);
         void DeleteCityAsync(int CityId);

         Task<City> FindCityAsync(int id);
    }
}