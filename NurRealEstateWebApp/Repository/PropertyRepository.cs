using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;

namespace NurRealEstateWebApp.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly NurDbContext nurDbContext;

        public PropertyRepository(NurDbContext nurDbContext)
        {
            this.nurDbContext = nurDbContext;
        }

        public async Task<bool> Persist(Property property)
        {
            nurDbContext.Set<Property>().Add(property);
            var saved = await nurDbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
