using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NurRealEstateWebApp.Entities
{
    public class Address
    {
        [Key]
        public Guid address_id { get; set; }

        [ForeignKey("property_id")]
        public Guid property_id { get; set; }
/*        public Property Property { get; set; }
*/
        [Required(ErrorMessage = "House number is required")]
        public string house_no { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }

        [Required(ErrorMessage = "Subcity is required")]
        public string sub_city { get; set; }
    }
}
