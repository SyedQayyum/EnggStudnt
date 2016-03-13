using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Contract
{
   public interface ICollegeBizManager
    {
       List<CollegeVO> GetAllColleges(bool? IsTop = null, string Cities = null, string Ratings = null);
       CollegeVO GetCollegeDetails(long? collId);
       List<ReviewVO> GetCollegeReviews(long? collId);
    }
}
