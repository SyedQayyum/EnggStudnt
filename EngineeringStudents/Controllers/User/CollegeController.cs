using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers
{
    public class CollegeController : Controller
    {
        // GET: FindCollege
        public ActionResult FindCollege()
        {
            return View("../User/College/FindCollege");
        }

        // GET: CollegeDetails
        public ActionResult CollegeDetails()
        {
            return View("../User/College/CollegeDetails");
        }
    }
}