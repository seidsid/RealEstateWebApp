using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using NurRealEstateWebApp.Entities;
using Pomelo.EntityFrameworkCore.MySql;

namespace NurRealEstateWebApp.Models
{
    public class NurDbContext : DbContext
    {

        public NurDbContext(DbContextOptions<NurDbContext> options) : base(options)
        {
           
        }

        public DbSet<Property> Property { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Agent> Agent { get; set; }
    }
}
