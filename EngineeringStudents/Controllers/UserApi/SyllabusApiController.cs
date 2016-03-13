using ES.Biz.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
    [RoutePrefix("api/syllabus")]
    public class SyllabusApiController : ApiController
    {
        private readonly ISyllabusBizManager _syllabusBizManager;
        public SyllabusApiController(ISyllabusBizManager syllabusBizManager)
        {
            _syllabusBizManager = syllabusBizManager;
        }


        [HttpGet]
        [Route("GetSyllabusByHeading")]
        public HttpResponseMessage GetSyllabusByHeading(string syllabusHeading = null, int? SubId = null, int? PageOrder = null)
        {
            syllabusHeading = syllabusHeading != "null" ? syllabusHeading : null;
            var Syllabus = _syllabusBizManager.GetSyllabusByHeading(syllabusHeading, SubId, PageOrder);
            if (Syllabus != null)
                return Request.CreateResponse(HttpStatusCode.OK, Syllabus);
            return Request.CreateErrorResponse(HttpStatusCode.OK, "No data Found.");
        }

    }
}
