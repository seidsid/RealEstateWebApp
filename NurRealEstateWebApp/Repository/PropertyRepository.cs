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

        public async Task<List<Property>> GetAllProperties()
        {
            var properties = await nurDbContext.Properties
                .Include(p => p.Address)
                .Include(p => p.Agent)
                .ThenInclude(a => a.Account)
                .ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyById(Guid id)
        {
            var property = await nurDbContext.Properties
                .Include(p => p.Address)
                .Include(p => p.Agent)
                .ThenInclude(a => a.Account)
                .FirstOrDefaultAsync(p => p.PropertyId == id);

            return property;
        }

        public async Task<List<Property>> GetFilters(FilterViewModel fmv)
        {
            IQueryable<Property> query = nurDbContext.Properties;

            // search, type, status filters

            if (!string.IsNullOrEmpty(fmv.SearchValue))
            {
                query = query.Include(p => p.Address)
                             .Include(p => p.Agent)
                             .ThenInclude(a => a.Account)
                .Where(p => p.Address.City.Contains(fmv.SearchValue) ||
                                         p.Address.SubCity.Contains(fmv.SearchValue) ||
                                         p.Title.Contains(fmv.SearchValue));
            }

            if (!string.IsNullOrEmpty(fmv.BuyRent))
            {
                query = query.Include(p => p.Address)
                             .Include(p => p.Agent)
                             .ThenInclude(a => a.Account)
                             .Where(p => p.Status.Contains(fmv.BuyRent));
            }

            if (!string.IsNullOrEmpty(fmv.PropertyType))
            {
                query = query.Include(p => p.Address)
                             .Include(p => p.Agent)
                             .ThenInclude(a => a.Account)
                             .Where(p => p.PropertyType.Contains(fmv.PropertyType));
            }

            if (!string.IsNullOrEmpty(fmv.bed))
            {
                query = query.Include(p => p.Address)
                             .Include(p => p.Agent)
                             .ThenInclude(a => a.Account)
                             .Where(p => p.NoBedrooms == int.Parse(fmv.bed));
            }

            if (!string.IsNullOrEmpty(fmv.bath))
            {
                query = query.Include(p => p.Address)
                             .Include(p => p.Agent)
                             .ThenInclude(a => a.Account)
                             .Where(p => p.NoBathrooms == int.Parse(fmv.bath));
            }

            if (fmv.min > 0)
            {
                query = query.Include(p => p.Address)
                             .Include(p => p.Agent)
                             .ThenInclude(a => a.Account)
                             .Where(p => p.Price >= fmv.min);
            }

            if (fmv.max > 0)
            {
                query = query.Include(p => p.Address)
                             .Include(p => p.Agent)
                             .ThenInclude(a => a.Account)
                             .Where(p => p.Price <= fmv.max);
            }

            return await query.Include(p => p.Address)
                             .Include(p => p.Agent)
                             .ThenInclude(a => a.Account).ToListAsync();
        }

    }
}
