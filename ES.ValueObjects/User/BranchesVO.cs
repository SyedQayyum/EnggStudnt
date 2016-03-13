using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects.User
{
    public class BranchesVO : BaseVO
    {
        public string branchAbbr { get; set; }
        public string branchName { get; set; }
    }
}
