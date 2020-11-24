using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace AtomHealth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConnectionDB _context;

        public HomeController(ConnectionDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.atomid = HttpContext.Session.GetString("atomid");
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUs contactUs)
        {

            if (ModelState.IsValid)
                return View();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("atomhealth1@gmail.com");
                mail.To.Add("shailzasharma.85@gmail.com");
                mail.Subject = contactUs.Message;

                mail.IsBodyHtml = true;
                string content = "Name: " + contactUs.Name;
                content += "<br/> Message: " + contactUs.Email;
                mail.Body = content;

                //Create SMTP instance
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                //Create Network credential
                NetworkCredential networkCredential = new NetworkCredential("atomhealth1@gmail.com", "Atomhealth@2020");
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                ViewBag.Message = "Mail Sent";

                ModelState.Clear();


            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message.ToString();
            }

            return View();
        }
    }
}
