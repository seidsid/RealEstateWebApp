using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;

namespace NurRealEstateWebApp.Repository
{
    public class AccountRepository
    {
        private readonly NurDbContext nurDbContext;

        public AccountRepository(NurDbContext _nurDbContext)
        {
            nurDbContext = _nurDbContext;
        }

        public async Task<bool> Persist(Account account)
        {
            nurDbContext.Set<Account>().Add(account);
            var saved = await nurDbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
