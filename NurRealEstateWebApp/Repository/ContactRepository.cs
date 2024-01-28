using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace NurRealEstateWebApp.Repository
{
    public class ContactRepository
    {
        private readonly NurDbContext nurDbContext;

        public ContactRepository(NurDbContext _nurDbContext) 
        {
            nurDbContext = _nurDbContext;
        }

        public async Task<bool> Persist(Contact contact)
        {
            nurDbContext.Set<Contact>().Add(contact);
            var saved = await nurDbContext.SaveChangesAsync();
            return saved > 0;
        }

    }
}
