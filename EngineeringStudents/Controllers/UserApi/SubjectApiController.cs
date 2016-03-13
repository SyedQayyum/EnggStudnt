
using ES.Biz.Contract;
using ES.ValueObjects;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace EngineeringStudents.Controllers
{
    [RoutePrefix("api/subject")]
    public class SubjectApiController : ApiController
    {
        private readonly ISubjectBizManager _subjectBizManager;

        public SubjectApiController(ISubjectBizManager subjectBizManager)
        {
            _subjectBizManager = subjectBizManager;
        }

        [Route("GetRelatedSubjectsBySubId")]
        public List<KeyValueVO> GetRelatedSubjectsBySubId(int subId)
        {
            return _subjectBizManager.GetRelatedSubjectsBySubId(subId);
        }

        [Route("GetAllSubjects")]
        public HttpResponseMessage GetAllSubject(int? subId = null, int? semId = null, int? branchId = null)
        {
            var Subjects = _subjectBizManager.GetAllSubjects(subId, semId, branchId);
            if (Subjects != null)
                return Request.CreateResponse(HttpStatusCode.OK, Subjects);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data Found.");
        }
    }
}
