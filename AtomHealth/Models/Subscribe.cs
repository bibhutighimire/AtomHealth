using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Subscribe
    { 

        public Guid subscribeid { get; set; }
        [Required(ErrorMessage = "Email Address can not be blank.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter Valid Email Address.")]
        public string email { get; set; }
}
}
