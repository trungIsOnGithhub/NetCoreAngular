using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent);

        void AddPropertyAsync(Property property);
        void DeletePropertyAsync(int id);

        Task<Property> GetPropertyDetailAsync(int id);
        Task<Property> GetPropertyByIdAsync(int id);
    }
}