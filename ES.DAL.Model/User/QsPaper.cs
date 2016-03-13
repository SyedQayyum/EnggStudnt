using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Model
{
    public class QsPaper : Base
    {
        public Nullable<int> qsId { get; set; }
        public int subId { get; set; }
        public int qsYear { get; set; }
        public string qsHeading { get; set; }
        public string qsContentRegular { get; set; }
        public string qsContentSupplementary { get; set; }
        public Nullable<int> qsPageOrder { get; set; }
    }
}
