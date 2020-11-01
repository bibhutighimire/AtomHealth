using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtomHealth.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ConnectionDB _context;

        public EmployeeController(ConnectionDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            return View(_context.tblAtom.ToList());
        }
    }
}
