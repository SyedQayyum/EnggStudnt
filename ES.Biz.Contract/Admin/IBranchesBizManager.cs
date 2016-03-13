using ES.ValueObjects;
using ES.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Contract
{
   public interface IBranchesBizManager
    {
       List<BranchesVO> GetAllBranches();
    }
}
