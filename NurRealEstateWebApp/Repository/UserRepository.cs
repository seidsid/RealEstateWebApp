using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;

namespace NurRealEstateWebApp.Repository
{
    public class UserRepository
    {
        private readonly NurDbContext nurDbContext;

        public UserRepository(NurDbContext _nurDbContext)
        {
            nurDbContext = _nurDbContext;
        }

        public async Task<bool> Persist(User user)
        {
            nurDbContext.Set<User>().Add(user);
            var saved = await nurDbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
