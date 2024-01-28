using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;

namespace NurRealEstateWebApp.Repository
{
    public class AdminRepository
    {
        private readonly NurDbContext nurDbContext;

        public AdminRepository(NurDbContext _nurDbContext)
        {
            nurDbContext = _nurDbContext;
        }

        public async Task<bool> Persist(Admin admin)
        {
            nurDbContext.Set<Admin>().Add(admin);
            var saved = await nurDbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
