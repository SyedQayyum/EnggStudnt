using ES.Biz.Contract;
using ES.Service.Contract;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Implementation
{
    public class BranchesService : IBranchesService
    {

        private readonly IBranchesBizManager _branchesBizManager;

        public BranchesService(IBranchesBizManager branchesBizManager)
        {
            _branchesBizManager = branchesBizManager;

        }

        public List<KeyValueVO> GetAllBranches()
        {
            return _branchesBizManager.GetAllBranches();
        }
    }
}
