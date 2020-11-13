using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using AtomHealth.Models;
using static AtomHealth.Models.SendEmail;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace AtomHealth.Controllers
{
    public class SendEmailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {


            return View();

        }


        [HttpPost]
        public IActionResult Index(SendEmail em)
        {
            string to = em.To;
            string subject = em.Subject;
            string body = em.Body;
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("ghimirebibhuti@gmail.com");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("ghimirebibhuti@gmail.com", "Ghimire1$");
            smtp.Send(mm);
            ViewBag.mailsentmessage = "Your message has been received. Thanks";

            return RedirectToAction("Index");

        }
    }
}
