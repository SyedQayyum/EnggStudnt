using ES.Biz.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
    [RoutePrefix("api/result")]
    public class ResultApiController : ApiController
    {
        private readonly IResultBizManager _resultBizManager;

        public ResultApiController(IResultBizManager resultBizManager)
        {
            _resultBizManager = resultBizManager;
        }

        [HttpGet]
        [Route("GetAllResults")]
        public HttpResponseMessage GetAllResults()
        {
            var Results = _resultBizManager.GetAllResults();
            if (Results != null)
                return Request.CreateResponse(HttpStatusCode.OK, Results);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data Found.");
        }
    }
}
