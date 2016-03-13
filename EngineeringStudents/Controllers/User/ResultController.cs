using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers.User
{
    public class ResultController : Controller
    {
       
        public ActionResult Index()
        {
            return View("../User/Result/Index");
        }
    }
}