using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AtomHealth.Models
{
    public class ContactUs
    {
        [Required(ErrorMessage = "Name can not be blank.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Address can not be blank.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter Valid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; }
    }
}
