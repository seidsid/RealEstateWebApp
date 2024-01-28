using NurRealEstateWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NurRealEstateWebApp.Entities
{
    public class Property
    {
        [Key]
        public Guid PropertyId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Property type is required.")]
        public string PropertyType { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Property size must be a positive number.")]
        public int PropertySize { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of bedrooms must be a positive number.")]
        public int NoBedrooms { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of bathrooms must be a positive number.")]
        public int NoBathrooms { get; set; }

        public bool HasMaidsRoom { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of parking spaces must be a positive number.")]
        public int NoParking { get; set; }

        [Required(ErrorMessage = "Listed date is required.")]
        public DateTime ListedDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        public virtual Address Address { get; set; }

        public virtual Agent Agent { get; set; }

        public virtual User User { get; set; }
    }
}