using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("../User/Home/Index");
        }
        // GET: AboutUs
        public ActionResult AboutUs()
        {
            return View("../User/Home/AboutUs");
        }

        public ActionResult ContactUs()
        {
            return View("../User/Home/ContactUs");
        }
        public ActionResult Advertise()
        {
            return View("../User/Home/Advertise");
        }
        public ActionResult Privacy()
        {
            return View("../User/Home/Privacy");
        }
    }
}