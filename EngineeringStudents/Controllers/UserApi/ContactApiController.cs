using ES.Biz.Contract;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
     [RoutePrefix("api/contact")]
    public class ContactApiController : ApiController
    {
        private readonly IContactBizManager _contactBizManager;
        public ContactApiController(IContactBizManager contactBizManager)
        {
            _contactBizManager = contactBizManager;
        }


        [HttpGet]
        [Route("ContactUs")]
        public HttpResponseMessage ContactUs()
        {
            ContactVO ObjContactVO = new ContactVO();
            ObjContactVO.SenderMessage = "Testing Email";
            var isDone = _contactBizManager.ContactUs(ObjContactVO);
            return Request.CreateResponse(HttpStatusCode.OK, isDone);
        }
    }
}
