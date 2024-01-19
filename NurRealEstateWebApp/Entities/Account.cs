using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NurRealEstateWebApp.Entities
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,100}$", ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }

        public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

        public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();

        public virtual ICollection<User> Users { get; set; } = new List<User>();

    }
}