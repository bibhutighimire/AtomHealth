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
                    msz.From = new MailAddress(vm.Email, "Visitor Email");//Email which you are getting 
                                                                          //from contact us page 
                    msz.To.Add("atomhealth1@gmail.com");//Where mail will be sent 
                    msz.Subject = "ACTION REQUIRED: Visitor Email Requires Response";


                    msz.Body =
                                $"Hello! You have a NEW message from Atom Health Visitor's Page.{Environment.NewLine}" +
                                $"{ Environment.NewLine}" +
                                $"Name: {vm.Name}{Environment.NewLine}" +

                                  $"{ Environment.NewLine}" +
                                $"Email: {vm.Email}{Environment.NewLine}" +
                              
                                  $"{ Environment.NewLine}" +
                                $"Message:{ Environment.NewLine}" +
                                 $"{vm.Message}";

                    SmtpClient smtpc = new SmtpClient();

                    smtpc.Host = "smtp.gmail.com";

                    smtpc.Port = 587;

                    smtpc.Credentials = new System.Net.NetworkCredential
                    ("atomhealth1@gmail.com", "Atomhealth@2020");

                    smtpc.EnableSsl = true;

                    smtpc.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us. We will get back to you soon.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }
            //response to contact 

            string to = vm.Email;
            string subject = "Thanks for Contacting Us!";
            string body =
            $"Hello User!,{Environment.NewLine}" +
            $"{ Environment.NewLine}" +
                       $"We want to let you know that we received your email message. Someone from our office will get back to you within 2-4 days.{Environment.NewLine}" +
                         $"{ Environment.NewLine}" +
                               $"Once again, thanks for contacting us. Stay Safe!{Environment.NewLine}" +
                               $"{ Environment.NewLine}" +
                        $"ATOM HEALTH TEAM";

            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("atomhealth1@gmail.com", "Atom Health Team");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("atomhealth1@gmail.com", "Atomhealth@2020");
            smtp.Send(mm);


            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
