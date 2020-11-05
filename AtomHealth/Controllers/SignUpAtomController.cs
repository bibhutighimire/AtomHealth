using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net;

using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;
using System.Management;

namespace AtomHealth.Controllers
{
    public class SignUpAtomController : Controller
    {
        private readonly ConnectionDB _context;

        public SignUpAtomController(ConnectionDB context)
        {
            _context = context;
        }
 
        public IActionResult Index()
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid=="1" || ViewBag.positionid == "2")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                return View(_context.tblAtom.ToList());
            }
            return RedirectToAction("Signin");
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SigninWithSession()
        {

            ViewBag.email = HttpContext.Session.GetString("email");
            ViewBag.password = HttpContext.Session.GetString("password");
            ViewBag.problem = "Invalid Email Address or Password. Try again!";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SigninPost(string email, string password)
        {
            if(email!=null && password != null)
            {
                //checks if user is patient
                var rightAtom = _context.tblAtom.Where(x => x.email == email && x.password == password).FirstOrDefault();

                if (rightAtom != null)
                {
                    ViewBag.firstname = rightAtom.firstname;
                    ViewBag.lastname = rightAtom.lastname;
                    ViewBag.positionid = rightAtom.positionid;
                    HttpContext.Session.SetString("firstname", rightAtom.firstname);
                    ViewBag.firstname = HttpContext.Session.GetString("firstname");
                    HttpContext.Session.SetString("lastname", rightAtom.lastname);
                    ViewBag.lastname = HttpContext.Session.GetString("lastname");
                    HttpContext.Session.SetString("positionid", Convert.ToString(rightAtom.positionid));
                    ViewBag.positionid = HttpContext.Session.GetString("positionid");
                    HttpContext.Session.SetString("atomid", Convert.ToString(rightAtom.atomid));
                    ViewBag.atomid = HttpContext.Session.GetString("atomid");
                    return View();
                }
                //checks if user is employee
                var rightEmployee = _context.tblEmployee.Where(x => x.email == email && x.password == password).FirstOrDefault();
                if (rightEmployee != null)
                {
                    ViewBag.firstname = rightEmployee.firstname;
                    ViewBag.lastname = rightEmployee.lastname;
                    ViewBag.positionid = rightEmployee.positionid;
                    HttpContext.Session.SetString("firstname", rightEmployee.firstname);
                    ViewBag.firstname = HttpContext.Session.GetString("firstname");
                    HttpContext.Session.SetString("lastname", rightEmployee.lastname);
                    ViewBag.lastname = HttpContext.Session.GetString("lastname");
                    HttpContext.Session.SetString("positionid", Convert.ToString(rightEmployee.positionid));
                    ViewBag.positionid = HttpContext.Session.GetString("positionid");
                    return View();

                }
                else
                {

                    HttpContext.Session.SetString("email", email);
                    HttpContext.Session.SetString("password", password);
                    return RedirectToAction("SigninWithSession");
                }
                
            }
            else
            {
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("password", password);
                return RedirectToAction("SigninWithSession");
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1" || ViewBag.positionid == "2")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                return View();
            }
            return RedirectToAction("Signin");
        }
        // Create method will add entire record of patient along with IP address
        [HttpPost]
        public IActionResult Create(Atom atom)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1" || ViewBag.positionid == "2")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                Atom tblAtom = new Atom();

                tblAtom.positionid = Convert.ToInt32("4");
                tblAtom.firstname = atom.firstname;
                tblAtom.middlename = atom.middlename;
                tblAtom.lastname = atom.lastname;
                tblAtom.healthid = atom.healthid;
                tblAtom.phone = atom.phone;
                tblAtom.email = atom.email;
                tblAtom.sex = atom.sex;
                tblAtom.height = atom.height;
                tblAtom.weight = atom.weight;
                tblAtom.ismarried = atom.ismarried;
                tblAtom.emergencyphone = atom.emergencyphone;
                tblAtom.relationship = atom.relationship;
                tblAtom.inmedicationnow = atom.inmedicationnow;
                tblAtom.medication = atom.medication;

                tblAtom.password = atom.password;
                tblAtom.registrationdate = DateTime.Now;
                tblAtom.dob = atom.dob;
                tblAtom.registeredby = tblAtom.firstname;

                _context.tblAtom.Add(tblAtom);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Signin");
        }
        [HttpGet]
        public IActionResult CreateForUserWhoNeedHelpBlank()
        {
            
            ViewBag.checkyouremail = HttpContext.Session.GetString("checkyouremail");
            
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            return View();
        }
        [HttpGet]
        public IActionResult CreateForUserWhoNeedHelp()
        {
            ViewBag.duplicateemail= HttpContext.Session.GetString("duplicateemail");
            ViewBag.checkyouremail = HttpContext.Session.GetString("checkyouremail");
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.middlename = HttpContext.Session.GetString("middlename");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.email = HttpContext.Session.GetString("email");
            ViewBag.password = HttpContext.Session.GetString("password");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateForUserWhoNeedHelp(Atom atom)
        {
            if (atom.firstname != null && atom.lastname != null && atom.email != null && atom.password != null)
            {
                var duplicateTarget = _context.tblAtom.Where(x => x.email == atom.email).FirstOrDefault();
                if(duplicateTarget==null)
                {
                    HttpContext.Session.SetString("checkyouremail", "Please check your email for validation");
                    //ViewBag.checkyouremail = HttpContext.Session.GetString("checkyouremail");
                    ViewBag.firstname = HttpContext.Session.GetString("firstname");
                    ViewBag.lastname = HttpContext.Session.GetString("lastname");
                    ViewBag.positionid = HttpContext.Session.GetString("positionid");
                    Atom tblAtom = new Atom();
                    tblAtom.positionid = Convert.ToInt32("4");
                    tblAtom.firstname = atom.firstname;
                    tblAtom.middlename = atom.middlename;
                    tblAtom.lastname = atom.lastname;
                    tblAtom.healthid = atom.healthid;
                    tblAtom.phone = atom.phone;
                    tblAtom.email = atom.email;
                    tblAtom.password = atom.password;
                   
                    tblAtom.registrationdate = DateTime.Now;
                    tblAtom.dob = atom.dob;
                    tblAtom.registeredby = tblAtom.firstname;
                    _context.tblAtom.Add(tblAtom);
                    _context.SaveChanges();
                    ViewBag.Success = "You are signed up successfully. Please check your email for verification.";
                    HttpContext.Session.SetString("checkyouremail", "Please check your email for validation");
               
                return RedirectToAction("CreateForUserWhoNeedHelpBlank");
                }
                else
                {
                    HttpContext.Session.SetString("firstname", atom.firstname);
                    if (atom.middlename != null)
                    {
                        HttpContext.Session.SetString("middlename", atom.middlename);
                    }
                    else
                    {
                        HttpContext.Session.SetString("middlename", "");
                    }
                    HttpContext.Session.SetString("lastname", atom.lastname);
                    HttpContext.Session.SetString("email", atom.email);
                    HttpContext.Session.SetString("password", atom.password);
                    ViewBag.FirstName = atom.firstname;
                    ViewBag.MiddleName = atom.middlename;
                    ViewBag.LastName = atom.lastname;
                    ViewBag.Email = atom.email;
                    ViewBag.Password = atom.password;
                    HttpContext.Session.SetString("duplicateemail", "This email address already exists.");
                   
                    return RedirectToAction("CreateForUserWhoNeedHelp");
                }
                //return View();
            }
            else
            {
                // All expected data not provided, so this will be our error state.
                //ViewBag.Error = "Please fill up all the fields.";
                // Store our data to re-add to the form.
                ViewBag.FirstName = atom.firstname;
                ViewBag.MiddleName = atom.middlename;
                ViewBag.LastName = atom.lastname;
                ViewBag.Email = atom.email;
                ViewBag.Password = atom.password;
                //ViewBag.Password = atom.confirmpassword;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1" || ViewBag.positionid == "2")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == id).FirstOrDefault();

                return View(targetToBeDeleted);
            }
            return RedirectToAction("Signin");
        }
        [HttpPost]
        public IActionResult Delete(Atom atom)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1" || ViewBag.positionid == "2")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == atom.atomid).FirstOrDefault();
                _context.tblAtom.Remove(targetToBeDeleted);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Signin");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1" || ViewBag.positionid == "2")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == id).FirstOrDefault();

                return View(targetToBeDeleted);
            }
            return RedirectToAction("Signin");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1" || ViewBag.positionid == "2")
            {
                ViewBag.firstname = HttpContext.Session.GetString("firstname");
                ViewBag.lastname = HttpContext.Session.GetString("lastname");
                ViewBag.positionid = HttpContext.Session.GetString("positionid");
                var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == id).FirstOrDefault();
                return View(targetToBeDeleted);
            }
            return RedirectToAction("Signin");
        }

        [HttpPost]
        public IActionResult Edit(Atom atom)
        {
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            if (ViewBag.positionid == "1" || ViewBag.positionid == "2")
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
                targetToBeDeleted.email = atom.email;
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Signin");

        }

        public IActionResult Signout()
        {
            HttpContext.Session.Clear();
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            ViewBag.firstname = null;
            ViewBag.lastname = null;
            ViewBag.positionid = null;

            return RedirectToAction("Signin");

        }




    }
}
