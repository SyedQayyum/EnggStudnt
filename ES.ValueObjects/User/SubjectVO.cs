using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
    public class SubjectVO : BaseVO
    {

        public Nullable<int> deptId { get; set; }
        public Nullable<int> semId { get; set; }
        public string subName { get; set; }
        public string deptName { get; set; }
        public string semName { get; set; }

    }
}
