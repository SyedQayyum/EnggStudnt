﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers
{
    public class CustomErrorController : Controller
    {
        // GET: CustomError
        public ActionResult PageNotFound()
        {
            return View("../Shared/CustomError/PageNotFound");
        }
    }
}