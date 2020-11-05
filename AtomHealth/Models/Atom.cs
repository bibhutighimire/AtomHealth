using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AtomHealth.Models
{
    [Table("tblAtom")]
    public class Atom
    {
        public int atomid { get; set; }
        public int positionid { get; set; }
        [Required(ErrorMessage = "First Name can not be blank.")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [Display(Name = "Middle Name")]
       
        public string middlename { get; set; }
        [Required(ErrorMessage = "Last Name can not be blank.")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        public long healthid { get; set; }
        public long phone { get; set; }
        [Required(ErrorMessage = "Email Address can not be blank.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please Enter Valid Email Address")]
        
        public string email { get; set; }
        public string sex { get; set; }
        //public string ipv6 { get; set; }
        public decimal height { get; set; }
        public int weight { get; set; }
        public string ismarried { get; set; }
        public long emergencyphone { get; set; }
        public string relationship { get; set; }
        public int inmedicationnow { get; set; }
        public string medication { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password can not be blank.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        // [NotMapped]
        //[Display(Name = "Confirm Password")]
        //[Required(ErrorMessage = "Password can not be blank.")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Passwords do not match.")]
        // [NotMapped]
        //public string confirmpassword { get; set; }
        public DateTime registrationdate { get; set; }
        public DateTime dob { get; set; }
        public string registeredby { get; set; }
        public string diseases { get; set; }
    }
}