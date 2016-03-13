using ES.Service.Contract.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers.User
{
    public class AdvertisementController : Controller
    {

        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public JsonResult GetAdvertisements()
        
        {
            var Advsertisement = _advertisementService.GetAdvertisements();
            var jsonAdvsertisement = JsonConvert.SerializeObject(Advsertisement);
            return Json(jsonAdvsertisement, JsonRequestBehavior.AllowGet);
        }
    }
}