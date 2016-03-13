using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Model
{
    public class Result : Base
    {
        public string resultHeading { get; set; }
        public string resultLink { get; set; }
        public DateTime resultDate { get; set; }
    }
}
