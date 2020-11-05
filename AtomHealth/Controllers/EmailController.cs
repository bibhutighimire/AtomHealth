using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using AtomHealth.Models;

namespace AtomHealth.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [BindProperty]
        public Email sendmail { get; set; }

        public async Task OnPost()
        {
            string To = sendmail.To;
            string From = sendmail.From;
            string Message = sendmail.Message;
            MailMessage mailmessage = new MailMessage();
            mailmessage.To.Add(To);
            //mailmessage.From = From;
            mailmessage.Body = Message;
            //mailmessage.Sender = From;
            mailmessage.IsBodyHtml = false;
            mailmessage.From = new MailAddress("ghimirebibhuti@gmail.com");



        }
    }
}
