using ES.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Model
{
    public class Operator : Base
    {
        public string opFisrtName { get; set; }
        public string opLastName { get; set; }
        public string opEmail { get; set; }
        public string opPassword { get; set; }
    }
}
