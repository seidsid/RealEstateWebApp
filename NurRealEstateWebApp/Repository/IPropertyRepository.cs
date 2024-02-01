using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NurRealEstateWebApp.Repository
{
    public interface IPropertyRepository
    {
         Task<bool> Persist(Property property);
         Task<List<Property>> GetAllProperties();
         Task<Property> GetPropertyById(Guid id);
         Task<List<Property>> GetFilters(FilterViewModel fmv);

    }
}