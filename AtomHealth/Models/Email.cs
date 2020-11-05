using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }

    }
}
