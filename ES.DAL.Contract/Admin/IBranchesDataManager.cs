using ES.DAL.Model;
using ES.DAL.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Contract
{
   public interface IBranchesDataManager
    {
       List<Branches> GetAllBranches();
    }
}
