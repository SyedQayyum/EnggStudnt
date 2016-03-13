using AutoMapper;
using Core.Common;
using ES.Biz.Contract;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.DAL.Model.User;
using ES.ValueObjects;
using ES.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Implementation
{
    public class BranchesBizManager : IBranchesBizManager
    {
        private readonly IBranchesDataManager _branchesDataManager;

        public BranchesBizManager(IBranchesDataManager branchesDataManager)
        {
            _branchesDataManager = branchesDataManager;
            AppHelper.CreateMap<BranchesVO, Branches>();
        }


        public List<BranchesVO> GetAllBranches()
        {
            return Mapper.Map<List<Branches>, List<BranchesVO>>(_branchesDataManager.GetAllBranches());
        }
    }
}
