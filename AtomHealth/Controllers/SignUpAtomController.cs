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
          
            return View(_context.tblAtom.ToList());
        }

        [HttpGet]
        public IActionResult Signin()
        {

            return View();
        }
       
        [HttpPost]
        public IActionResult SigninPost(string username, string password)
        {
            //checks if user is patient
            var rightAtom = _context.tblAtom.Where(x => x.username == username && x.password == password).FirstOrDefault();
            
            if(rightAtom!=null)
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
                return View();
            }
            //checks if user is employee
            var rightEmployee =_context.tblEmployee.Where(x => x.username == username && x.password == password).FirstOrDefault();
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

                //checks if user is admin
                //var rightEmployee = _context.tblEmployee.Where(x => x.username == atom.username && x.password == atom.password).FirstOrDefault();
                //if (rightEmployee != null)
                //{
                //    ViewBag.firstname = rightEmployee.firstname;
                //    ViewBag.lastname = rightEmployee.lastname;
                //    ViewBag.positionid = rightEmployee.positionid;
                //    return RedirectToAction("Index", "Home");
                //}
            }
                return RedirectToAction("Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            return View();
        }
        // Create method will add entire record of patient along with IP address
        [HttpPost]
        public IActionResult Create(Atom atom)
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
            tblAtom.username = atom.username;
            tblAtom.password = atom.password;
            tblAtom.registrationdate = DateTime.Now;
            tblAtom.dob = atom.dob;
            tblAtom.registeredby = tblAtom.firstname;
            
            _context.tblAtom.Add(tblAtom);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateForUserWhoNeedHelp()
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            return View();
        }
        [HttpPost]

        public IActionResult CreateForUserWhoNeedHelpPost(Atom atom)
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
            tblAtom.username = atom.username;
            tblAtom.password = atom.password;
            tblAtom.registrationdate = DateTime.Now;
            tblAtom.dob = atom.dob;
            tblAtom.registeredby = tblAtom.firstname;
            
            
            //IPV4 Address code start
            IPHostEntry IPHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            string IpAddress = Convert.ToString(IPHostInfo.AddressList.FirstOrDefault(Address => Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork));
            tblAtom.ipadd = IpAddress;
            //IPV4 Address code ends

            //MAC Address code STARTS
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = string.Empty;
            
            foreach(ManagementObject mo in moc)
            {
                if(MACAddress==string.Empty)
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "-");
            tblAtom.macadd = MACAddress;
            //MAC Address code ends

            _context.tblAtom.Add(tblAtom);
            _context.SaveChanges();
            return RedirectToAction("Signin");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            var targetToBeDeleted = _context.tblAtom.Where(x=>x.atomid==id).FirstOrDefault();

            return View(targetToBeDeleted);
        }
        [HttpPost]
        public IActionResult Delete(Atom atom)
        {
            ViewBag.firstname = HttpContext.Session.GetString("firstname");
            ViewBag.lastname = HttpContext.Session.GetString("lastname");
            ViewBag.positionid = HttpContext.Session.GetString("positionid");
            var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == atom.atomid).FirstOrDefault();
            _context.tblAtom.Remove(targetToBeDeleted);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
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
            var targetToBeDeleted = _context.tblAtom.Where(x => x.atomid == id).FirstOrDefault();

            return View(targetToBeDeleted);
        }

        [HttpPost]
        public IActionResult Edit(Atom atom)
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
            targetToBeDeleted.username = atom.username;
            
            targetToBeDeleted.dob = atom.dob;
            
            targetToBeDeleted.diseases = atom.diseases;
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public IActionResult Signout()
        {
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
