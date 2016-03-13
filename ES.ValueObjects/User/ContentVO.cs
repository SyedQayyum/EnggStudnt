using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
    public class ContentVO : BaseVO
    {
        public Nullable<int> subId { get; set; }
        public string contHeading { get; set; }
        public string contDetail { get; set; }
        public Nullable<int> contPageOrder { get; set; }
        public Nullable<bool> contIsQsPaper { get; set; }
        public Nullable<bool> contIsSyllabus { get; set; }
    }
}
