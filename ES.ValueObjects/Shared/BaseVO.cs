using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
    public class BaseVO
    {
        public long id { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public long createdBy { get; set; }
        public Nullable<System.DateTime> modifiedDate { get; set; }
        public long modifiedBy { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public Nullable<bool> isPublised { get; set; }
    }
}
