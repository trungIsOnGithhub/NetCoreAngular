using webapi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace webapi.Interfaces
{
    public interface ICityRepository
    {
         Task<IEnumerable<City>> GetCitiesAsync();
         void AddCity(City city);
         void DeleteCity(int CityId);
         Task<City> FindCity(int id);
    }
}