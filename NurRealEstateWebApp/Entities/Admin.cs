using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NurRealEstateWebApp.Entities
{
    public class Admin
    {
        [Key]
        public Guid AdminId { get; set; }

        [Required(ErrorMessage = "Account is required.")]
        public virtual Account Account { get; set; }

        public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();

        [Required(ErrorMessage = "Contact is required.")]
        public virtual Contact Contact { get; set; }
    }
}