using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AtomHealth.Models
{
    public class ContactUs
    {
        [Required(ErrorMessage = "Name cannot be blank.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Address can not be blank.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter Valid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject cannot be blank.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message cannot be blank.")]
        public string Message { get; set; }
    }
}
