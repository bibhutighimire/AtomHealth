using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtomHealth.Controllers
{
    public class AtomController : Controller
    {
        private readonly ConnectionDB _context;
        public AtomController(ConnectionDB context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Profile(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "4")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                ViewBag.atomid = HttpContext.Session.GetString("atomid");
                var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == id).FirstOrDefault();

                return View(targetToBeDeleted);
            }
            return RedirectToAction("Signin", "SignUpAtom");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "4")
            {
                ViewBag.atomid = HttpContext.Session.GetString("atomid");
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == id).FirstOrDefault();
                return View(targetToBeDeleted);
            }
            return RedirectToAction("Signin", "SignUpAtom");
        }

        [HttpPost]
        public IActionResult Edit(Atom atom)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "4")
            {
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
                //targetToBeDeleted.email = atom.email;
                targetToBeDeleted.sex = atom.sex;
                targetToBeDeleted.height = atom.height;
                targetToBeDeleted.weight = atom.weight;
                targetToBeDeleted.ismarried = atom.ismarried;
                targetToBeDeleted.emergencyphone = atom.emergencyphone;
                targetToBeDeleted.relationship = atom.relationship;
                targetToBeDeleted.inmedicationnow = atom.inmedicationnow;
                targetToBeDeleted.medication = atom.medication;


                targetToBeDeleted.dob = atom.dob;

                targetToBeDeleted.diseases = atom.diseases;
                _context.SaveChanges();
                return RedirectToAction("Profile","Atom", new { id = atom.atomid });
            }
            return RedirectToAction("Signin", "SignUpAtom");

        }

    }
}
