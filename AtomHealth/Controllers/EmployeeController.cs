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

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == id).FirstOrDefault();

            return View(targetToBeDeleted);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == id).FirstOrDefault();

            return View(targetToBeDeleted);
        }

        [HttpPost]
        public IActionResult Edit(Atom atom)
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == atom.atomid).FirstOrDefault();
            targetToBeDeleted.positionid = Convert.ToInt32("4");
            targetToBeDeleted.firstname = atom.firstname;
            targetToBeDeleted.middlename = atom.middlename;
            targetToBeDeleted.lastname = atom.lastname;
            targetToBeDeleted.healthid = atom.healthid;
            targetToBeDeleted.phone = atom.phone;
            targetToBeDeleted.email = atom.email;
            targetToBeDeleted.sex = atom.sex;
            targetToBeDeleted.height = atom.height;
            targetToBeDeleted.weight = atom.weight;
            targetToBeDeleted.ismarried = atom.ismarried;
            targetToBeDeleted.emergencyphone = atom.emergencyphone;
            targetToBeDeleted.relationship = atom.relationship;
            targetToBeDeleted.inmedicationnow = atom.inmedicationnow;
            targetToBeDeleted.medication = atom.medication;
            targetToBeDeleted.username = atom.username;

            targetToBeDeleted.dob = atom.dob;

            targetToBeDeleted.diseases = atom.diseases;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
