using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NurRealEstateWebApp.Entities
{
    public class Agent
    {
        [Key]
        public Guid AgentId { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Languages is required.")]
        public string Languages { get; set; }

        [Required(ErrorMessage = "Experience since date is required.")]
        public DateTime ExperienceSince { get; set; }

        [Required(ErrorMessage = "Account is required.")]
        public virtual Account Account { get; set; }

        public virtual Admin Admin { get; set; }

        [Required(ErrorMessage = "Contact is required.")]
        public virtual Contact Contact { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}