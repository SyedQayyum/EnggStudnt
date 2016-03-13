using ES.Biz.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
    [RoutePrefix("api/common")]
    public class CommonApiController : ApiController
    {

        private readonly ICommonBizManager _commonBizManager;

        public CommonApiController(ICommonBizManager commonBizManager)
        {
            _commonBizManager = commonBizManager;
        }

        [HttpGet]
        [Route("GetAllCities")]
        public HttpResponseMessage GetAllCities()
        {
            var Cities = _commonBizManager.GetAllCities();
            if (Cities != null)
                return Request.CreateResponse(HttpStatusCode.OK, Cities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data Found.");
        }

    }
}
