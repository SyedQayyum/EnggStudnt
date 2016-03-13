using ES.Biz.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
    [RoutePrefix("api/college")]
    public class CollegeApiController : ApiController
    {
        private readonly ICollegeBizManager _collegeBizManager;
        public CollegeApiController(ICollegeBizManager collegeBizManager)
        {
            _collegeBizManager = collegeBizManager;
        }


        [HttpGet]
        [Route("GetAllColleges")]
        public HttpResponseMessage GetAllColleges(bool? isTop = null, string cities = null, string ratings = null)
        {
            cities = cities == "null" ? null : cities;
            ratings = ratings == "null" ? null : ratings;
            if (string.IsNullOrEmpty(cities) && string.IsNullOrEmpty(ratings))
                isTop = true;
            var Colleges = _collegeBizManager.GetAllColleges(isTop, cities, ratings);
            if (Colleges != null)
                return Request.CreateResponse(HttpStatusCode.OK, Colleges);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data Found.");
        }

        [HttpGet]
        [Route("GetCollegeDetails")]
        public HttpResponseMessage GetCollegeDetails(long? collId)
        {
            var College = _collegeBizManager.GetCollegeDetails(collId);
            if (College != null)
                return Request.CreateResponse(HttpStatusCode.OK, College);
            return Request.CreateErrorResponse(HttpStatusCode.OK, "No data Found.");
        }

        [HttpGet]
        [Route("GetCollegeReviews")]
        public HttpResponseMessage GetCollegeReviews(long? collId)
        {
            var Reviews = _collegeBizManager.GetCollegeReviews(collId);
            if (Reviews != null)
                return Request.CreateResponse(HttpStatusCode.OK, Reviews);
            return Request.CreateErrorResponse(HttpStatusCode.OK, "No data Found.");
        }
    }
}
