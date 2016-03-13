using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
    public class DepartmentVO : BaseVO
    {
        public string deptName { get; set; }
        public string deptAbbrName { get; set; }
    }
}
