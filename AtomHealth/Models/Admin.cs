using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Admin
    {
        public Guid adminid { get; set; }
        public int positionid { get; set; }
       
        [Required(ErrorMessage = "Email Address can not be blank.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter Valid Email Address.")]

        public string email { get; set; }
       
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password can not be blank.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
