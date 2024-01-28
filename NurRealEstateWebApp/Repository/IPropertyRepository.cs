using NurRealEstateWebApp.Entities;

namespace NurRealEstateWebApp.Repository
{
    public interface IPropertyRepository
    {

         public Task<bool> Persist(Property property);

    }
}
