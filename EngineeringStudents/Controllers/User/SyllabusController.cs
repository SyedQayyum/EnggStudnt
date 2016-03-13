using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers.User
{
    public class SyllabusController : Controller
    {
        public ActionResult Index()
        {
            return View("../User/Syllabus/Index");
        }
    }
}