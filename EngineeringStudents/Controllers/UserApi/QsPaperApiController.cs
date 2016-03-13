using ES.Biz.Contract;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
    [RoutePrefix("api/QsPaper")]
    public class QsPaperApiController : ApiController
    {

       private readonly IQsPaperBizManager _qsPaperBizManager;
       public QsPaperApiController(IQsPaperBizManager qsPaperBizManager)
        {
            _qsPaperBizManager = qsPaperBizManager;
        }


        [HttpGet]
        [Route("GetQsPaperByHeading")]
        public HttpResponseMessage GetQsPaperByHeading(string QsHeading = null, int? SubId = null, int? PageOrder = null)
        {
            QsHeading = QsHeading != "null" ? QsHeading : null;
            var QsPaper = _qsPaperBizManager.GetQsPaperByHeading(QsHeading, SubId, PageOrder);
            if (QsPaper != null)
                return Request.CreateResponse(HttpStatusCode.OK, QsPaper);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data Found.");
        }

        [HttpGet]
        [Route("GetQsPaperYearBySubjectId")]
        public HttpResponseMessage GetQsPaperYearBySubjectId(int subjectId)
        {
            var qsPaperYears = _qsPaperBizManager.GetQsPaperYearBySubjectId(subjectId);
            if (qsPaperYears != null)
                return Request.CreateResponse(HttpStatusCode.OK, qsPaperYears);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data Found.");

        }

    }
}
