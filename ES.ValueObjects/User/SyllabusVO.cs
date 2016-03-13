using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
   public class SyllabusVO : BaseVO
    {
        
        public int subId { get; set; }
        public int branchId { get; set; }
        public int semId { get; set; }
        public int syllabusYear { get; set; }
        public string syllabusHeading { get; set; }
        public string syllabusContent { get; set; }
        public Nullable<int> syllabusPageOrder { get; set; }

    }
}
