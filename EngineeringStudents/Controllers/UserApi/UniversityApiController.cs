using ES.Biz.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
   [RoutePrefix("api/university")]
    public class UniversityApiController : ApiController
    {
        private readonly IUniversityBizManager _universityBizManager;

        public UniversityApiController(IUniversityBizManager universityBizManager)
        {
            _universityBizManager = universityBizManager;
        }

        [HttpGet]
        [Route("GetAllUniversities")]
        public HttpResponseMessage GetAllUniversities()
        {
            var University = _universityBizManager.GetAllUniversities();
            if (University != null)
                return Request.CreateResponse(HttpStatusCode.OK, University);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data Found.");
        }
    }
}
