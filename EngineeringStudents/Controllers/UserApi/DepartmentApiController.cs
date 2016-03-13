using ES.Biz.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
    [RoutePrefix("api/department")]
    public class DepartmentApiController : ApiController
    {
        private readonly IDepartmentBizManager _departmentBizManager;
        public DepartmentApiController(IDepartmentBizManager departmentBizManager)
        {
            _departmentBizManager = departmentBizManager;
        }

        [HttpGet]
        [Route("GetAllDepartments")]
        public HttpResponseMessage GetAllDepartments()
        {
            var Departments = _departmentBizManager.GetAllDepartments();
            if (Departments != null)
                return Request.CreateResponse(HttpStatusCode.OK, Departments);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data Found.");
        }
    }
}
