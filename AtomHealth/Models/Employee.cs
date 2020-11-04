using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Employee
    {
        public int employeeid { get; set; }
        public int positionid { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public long phone { get; set; }
        public string email { get; set; }
        public string sex { get; set; }
      
        public string password { get; set; }
        public DateTime registrationdate { get; set; }
        public DateTime dob { get; set; }
        public string registeredby { get; set; }
    }
}
