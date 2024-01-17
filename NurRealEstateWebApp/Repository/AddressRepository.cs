using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;

namespace NurRealEstateWebApp.Repository
{
    public class AddressRepository
    {
        private readonly NurDbContext nurDbContext;

        public AddressRepository(NurDbContext _nurDbContext)
        {
            nurDbContext = _nurDbContext;
        }

        public async Task<bool> Persist(Address address)
        {
            nurDbContext.Set<Address>().Add(address);
            var saved = await nurDbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
