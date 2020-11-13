using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtomHealth.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ConnectionDB _context;

        public SubscribeController(ConnectionDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subscribe s)
        {
            Subscribe tblS = new Subscribe();
            var target = _context.tblSubscribe.Where(x => x.email == s.email).FirstOrDefault();
            if(target!=null)
            {
                ViewBag.alreadysub = "We already have your email address on our subscription list. Thanks!";
                return View();
            }
            else
            {
                tblS.email = s.email;
                _context.tblSubscribe.Add(tblS);
                _context.SaveChanges();
                ViewBag.msg = " You are now Subscribed. Thanks!";

                return View();
            }
           
        }
    }
}
