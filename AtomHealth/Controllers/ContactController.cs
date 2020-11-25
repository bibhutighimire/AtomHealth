using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace AtomHealth.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactUs vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("atomhealth1@gmail.com");//Where mail will be sent 
                    msz.Subject = vm.Subject;


                    msz.Body =
                                $"Hello! You have a NEW message from Atom Health Visitor's Page.{Environment.NewLine}" +
                                $"{ Environment.NewLine}" +
                                $"Name: {vm.Name}{Environment.NewLine}" +

                                  $"{ Environment.NewLine}" +
                                $"Email: {vm.Email}{Environment.NewLine}" +
                                  $"{ Environment.NewLine}" +
                                  $"{ Environment.NewLine}" +
                                $"Message:{ Environment.NewLine}" +
                                 $"{vm.Message}";

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("atomhealth1@gmail.com", "Atomhealth@2020");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us. We will get back to you soon.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
