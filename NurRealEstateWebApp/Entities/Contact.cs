using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NurRealEstateWebApp.Entities
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?\d{1,}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [RegularExpression(@"^\+?\d{1,}$", ErrorMessage = "Invalid WhatsApp number.")]
        public string WhatsappNo { get; set; }
    }
}