using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NurRealEstateWebApp.Entities
{
    public class Property
    {
        [Key]
        public Guid property_id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Property type is required")]
        public string property_type { get; set; }

        [Required(ErrorMessage = "Property size is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Property size must be a positive value")]
        public decimal property_size { get; set; }

        [Required(ErrorMessage = "Number of bedrooms is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Number of bedrooms must be a positive value")]
        public int no_bedrooms { get; set; }

        [Required(ErrorMessage = "Number of bathrooms is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Number of bathrooms must be a positive value")]
        public int no_bathrooms { get; set; }

        public bool has_maidsRoom { get; set; }

        [Required(ErrorMessage = "Number of parking spaces is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Number of parking spaces must be a positive value")]
        public int no_parking { get; set; }

        [Required(ErrorMessage = "Listed date is required")]
        public DateTime listed_date { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string status { get; set; }

        [ForeignKey("user_id")]
        public Guid user_id { get; set; }
/*        public User User { get; set; }
*/
        [ForeignKey("agent_id")]
        public Guid agent_id { get; set; }
/*        public Agent Agent { get; set; }
*/
/*        public Address Address { get; set; }
*/    }
}
