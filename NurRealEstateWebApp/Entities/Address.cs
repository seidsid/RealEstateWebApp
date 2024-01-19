using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NurRealEstateWebApp.Entities
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [Required(ErrorMessage = "Property ID is required.")]
        public Guid PropertyId { get; set; }

        [Required(ErrorMessage = "House number is required.")]
        public string HouseNo { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Subcity is required.")]
        public string SubCity { get; set; }

        public virtual Property Property { get; set; }
    }
}