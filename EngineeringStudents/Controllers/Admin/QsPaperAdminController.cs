using ES.Biz.Contract;
using ES.ValueObjects;
using System.Linq;
using System.Web.Mvc;

namespace EngineeringStudents.Controllers.Admin
{
    public class QsPaperAdminController : Controller
    {

        private readonly ISubjectBizManager _subjectBizManager;
        private readonly IBranchesBizManager _branchesBizManager;
        private readonly ISemesterBizManager _semesterBizManager;


        public QsPaperAdminController(ISubjectBizManager subjectBizManager, IBranchesBizManager branchesBizManager, ISemesterBizManager semesterBizManager)
        {
            _subjectBizManager = subjectBizManager;
            _branchesBizManager = branchesBizManager;
            _semesterBizManager = semesterBizManager;
        }
        // GET: QsPaperAdmin
        public ActionResult Index()
        {
            return View("../Admin/QsPaper/Index");
        }

        public ActionResult Create()
        {
            QsPaperVO objQsPaperVO = new QsPaperVO();
            //objQsPaperVO.Subjects = _subjectBizManager.GetAllSubjects(null, null).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            //objQsPaperVO.Semesters = _semesterBizManager.GetAllSemesters().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            objQsPaperVO.Branches = _branchesBizManager.GetAllBranches().Select(x => new SelectListItem { Text = x.branchAbbr, Value = x.id.ToString() }).ToList(); 
            return View("../Admin/QsPaper/Create", objQsPaperVO);
        }

        //[HttpPost]
        //public ActionResult Create(OperatorVO ObjOperatorVO)
        //{
        //    int OperatorId = _operatorBizManager.CreateOperator(ObjOperatorVO);
        //    return View();
        //}
    }
}