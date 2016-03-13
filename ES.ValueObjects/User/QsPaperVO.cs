using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ES.ValueObjects
{
    public class QsPaperVO : BaseVO
    {
        public Nullable<int> qsId { get; set; }
        public int subId { get; set; }
        public int branchId { get; set; }
        public int semesterId{ get; set; }
        public int qsYear { get; set; }
        public string qsHeading { get; set; }
        public string qsContentRegular { get; set; }
        public string qsContentSupplementary { get; set; }
        public Nullable<int> qsPageOrder { get; set; }

        public IEnumerable<SelectListItem> Subjects { get; set; }
        public IEnumerable<SelectListItem> Branches { get; set; }
        public IEnumerable<SelectListItem> Semesters { get; set; }
    }
}
