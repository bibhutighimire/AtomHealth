using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Email
    {
        public int emailid { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        //public string EmailAddress { get; set; }
        public string Body { get; set; }

    }
}
