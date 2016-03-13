using ES.Biz.Contract;
using ES.ValueObjects;
using System.Collections.Generic;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{

    [RoutePrefix("api/advertisement")]
    public class AdvertisementApiController : ApiController
    {


         private readonly IAdvertisementBizManager _advertisementBizManager;
         public AdvertisementApiController(IAdvertisementBizManager advertisementBizManager)
        {
            _advertisementBizManager = advertisementBizManager;
        }


        [HttpGet]
        [Route("GetAdvertisements")]
        public List<AdvertisementVO> GetAdvertisements(string Url)
        {
            List<AdvertisementVO> AdvertisementList = _advertisementBizManager.GetAdvertisements(Url);
            return AdvertisementList;
        }
    }
}