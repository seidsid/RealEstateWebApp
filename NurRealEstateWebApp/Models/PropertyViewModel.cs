using Microsoft.AspNetCore.Mvc;
using NurRealEstateWebApp.Entities;
    using System.ComponentModel.DataAnnotations;

    namespace NurRealEstateWebApp.Models
    {
        public class PropertyViewModel
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

            public AddressViewModel Address { get; set; }

            public List<IFormFile> Images { get; set; }

            public Guid Agent_id { get; set; }

            public Guid User_id { get; set; }
        }
    }
