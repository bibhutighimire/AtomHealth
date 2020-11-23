using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrypt;

namespace AtomHealth.Controllers
{
    public class AdminController : Controller
    {
        private readonly ConnectionDB _context;
        public AdminController(ConnectionDB context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            //ViewBag.Success = HttpContext.Session.GetString("checkyouremail");
            return View();
        }

        [HttpPost]

        public IActionResult AddNewAdmin(Admin admin)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            if (admin.email != null && admin.password != null)
            {
                Admin tblAdmin = new Admin();
                tblAdmin.positionid = Convert.ToInt32("1");
                tblAdmin.email = admin.email;
                tblAdmin.password = encoder.Encode(admin.password);
                _context.tblAdmin.Add(tblAdmin);
                _context.SaveChanges();
               // HttpContext.Session.SetString("checkyouremail", "Registration Successful! Please log in!");
                return RedirectToAction("Create");
            }
            return RedirectToAction("Create");
        }
    }
}
