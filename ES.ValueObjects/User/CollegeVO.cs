using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
    public class CollegeVO : BaseVO
    {
        public string collName { get; set; }
        public string collAddress { get; set; }
        public string collCity { get; set; }
        public int collUniversity { get; set; }
        public string collLogo { get; set; }
        public int collRating { get; set; }
        public string collPhone { get; set; }
        public string collWebsite { get; set; }
        public string collFax { get; set; }
        public string collEmail { get; set; }
        public string coursesOffered { get; set; }
        public string collStablishedYear { get; set; }
        public bool collIsTop { get; set; }

    }
}
