using ES.Biz.Contract;
using ES.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EngineeringStudents.Controllers
{
    public class BranchesApiController : ApiController
    {
          private readonly IBranchesBizManager _branchesBizManager;
          public BranchesApiController(IBranchesBizManager branchesBizManager)
        {
            _branchesBizManager = branchesBizManager;
        }


        [HttpGet]
        [Route("GetAllBranches")]
        public List<BranchesVO> GetAdvertisements(string Url)
        {
            List<BranchesVO> branchesList = _branchesBizManager.GetAllBranches();
            return branchesList;
        }
    }
}
