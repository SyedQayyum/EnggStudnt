using ES.Biz.Contract;
using ES.ValueObjects;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IOperatorBizManager _operatorBizManager;
        public OperatorController(IOperatorBizManager operatorBizManager)
        {
            _operatorBizManager = operatorBizManager;
        }

        // GET: Operator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            OperatorVO objOperatorVO = new OperatorVO();
            return View("../Admin/Operator/Create", objOperatorVO);
        }

        [HttpPost]
        public ActionResult Create(OperatorVO ObjOperatorVO)
        {
            int OperatorId = _operatorBizManager.CreateOperator(ObjOperatorVO);
            return View();
        }
    }
}