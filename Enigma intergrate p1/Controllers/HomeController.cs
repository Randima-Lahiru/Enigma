using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enigma_intergrate_p1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult PatientPage()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult NonCommunicableDiseases()
        {
            return View();
        }
        //public ActionResult SymptomsChecker()
        //{
        //    return View();
        //}
        //public ActionResult Madusha1()
        //{
        //    return View();
        //}
        //public ActionResult DiseasesDescriptionGetDoctor()
        //{
        //    return View();
        //}
        public ActionResult DoctorPage()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        public ActionResult PharmacyPage()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        public ActionResult HospitalPage()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        public ActionResult PatientRegistration()
        {
            return View();
        }
        public ActionResult DoctorRegistration()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        public ActionResult AdminPage()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        public ActionResult PharmacyRegistration()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        public ActionResult HospitalRegistration()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        public ActionResult AdminLogin()
        {
            
            return View();
        }
        public ActionResult ReportPage()
        {

            return View();
        }
        public ActionResult PharmacySearch()
        {
            return View();
        }
        public ActionResult GetSubmitReport()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
    }
}