using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Atom
    {
        public int atomid { get; set; }
        public int positionid { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public long healthid { get; set; }
        public long phone { get; set; }
        public string email { get; set; }
        public string sex { get; set; }
        public string ipadd { get; set; }
        public string macadd { get; set; }
        public string ipv6 { get; set; }

        public decimal height { get; set; }
        public int weight { get; set; }
        public string ismarried { get; set; }
        public long emergencyphone { get; set; }
        public string relationship { get; set; }
        public int inmedicationnow { get; set; }
        public string medication { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime registrationdate { get; set; }
        public DateTime dob { get; set; }
        public string registeredby { get; set; }
        public string diseases { get; set; }
    }
}
