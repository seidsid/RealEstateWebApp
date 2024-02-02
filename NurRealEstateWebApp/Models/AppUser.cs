using Microsoft.AspNetCore.Identity;

namespace NurRealEstateWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public Guid AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
