using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
    public class ResultVO : BaseVO
    {

        public string resultHeading { get; set; }
        public string resultLink { get; set; }
        public DateTime resultDate { get; set; }

    }
}
