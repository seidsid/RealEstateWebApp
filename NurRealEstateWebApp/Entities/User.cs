using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NurRealEstateWebApp.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Account is required.")]
        public virtual Account Account { get; set; }

        [Required(ErrorMessage = "Contact is required.")]
        public virtual Contact Contact { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}