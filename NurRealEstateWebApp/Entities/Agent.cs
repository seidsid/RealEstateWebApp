using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NurRealEstateWebApp.Entities
{
    public class Agent
    {
        [Key]
        public Guid agent_id { get; set; }

        [Required]
        [StringLength(100)]
        public string nationality { get; set; }

        [Required]
        [StringLength(100)]
        public string languages { get; set; }

        [Required]
        public DateTime experience_since { get; set; }

        [ForeignKey("contact_id")]
        public Guid contact_id { get; set; }
/*        public Contact Contact { get; set; }
*/
        [ForeignKey("account_id")]
        public Guid account_id { get; set; }

/*        public Account Account { get; set; }
*/
/*        public ICollection<Property> Properties { get; set; }
*/    }
}
