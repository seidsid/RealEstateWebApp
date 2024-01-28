using NurRealEstateWebApp.Models;

namespace NurRealEstateWebApp.Service
{
    public interface IPropertyService
    {
        public Task CreateProperty(PropertyViewModel pvm);
    }
}
