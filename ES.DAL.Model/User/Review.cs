using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Model
{
    public class Review : Base
    {
        public Nullable<int> collId { get; set; }
        public string revUserName { get; set; }
        public string revUserEmail { get; set; }
        public int revRating { get; set; }
        public string revReview { get; set; }
    }
}
