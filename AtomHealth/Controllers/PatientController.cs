using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtomHealth.Controllers
{
    public class PatientController : Controller
    {
        private readonly ConnectionDB _context;
        public PatientController(ConnectionDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                
                return View(_context.tblAtom.ToList());
            }
            return RedirectToAction("Signin", "SignUpAtom");

        }
    }
}
