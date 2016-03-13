using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
    public class CustomerVO : BaseVO
    {
        public string custName { get; set; }
        public string custAddress { get; set; }
        public string custPhone { get; set; }
        public string custMobile { get; set; }
    }
}
