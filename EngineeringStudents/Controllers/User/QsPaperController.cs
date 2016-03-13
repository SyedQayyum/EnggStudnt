using ES.Biz.Contract;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers
{
    public class QsPaperController : Controller
    {
        private readonly IQsPaperBizManager _qsPaperBizManager;

        public QsPaperController(IQsPaperBizManager qsPaperBizManager)
        {
            _qsPaperBizManager = qsPaperBizManager;
        }


        public ActionResult Index()
        {
            return View("../User/QsPaper/Index");
        }

        public ActionResult AvailableSubjects()
        {
            return View("../User/QsPaper/AvailableSubjects");
        }

        public ActionResult QsPaperDetails()
        {
            return View("../User/QsPaper/QsPaperDetails");
        }

        [HttpGet]
        public Object GetQsPaperByHeading(string QsHeading, int? SubjectId,int? PageOrder)
        {
            var QsPaper = _qsPaperBizManager.GetQsPaperByHeading(QsHeading, SubjectId, PageOrder);
            var jsonQsPaper = JsonConvert.SerializeObject(QsPaper);
            return Json(jsonQsPaper, JsonRequestBehavior.AllowGet);
        }
    }

}