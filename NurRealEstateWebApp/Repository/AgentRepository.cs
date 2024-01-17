using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;

namespace NurRealEstateWebApp.Repository
{
    public class AgentRepository
    {
        private readonly NurDbContext nurDbContext;

        public AgentRepository(NurDbContext _nurDbContext)
        {
            nurDbContext = _nurDbContext;
        }

        public async Task<bool> Persist(Agent agent)
        {
            nurDbContext.Set<Agent>().Add(agent);
            var saved = await nurDbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}
