using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtomHealth.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            return View();
        }
    }
}
