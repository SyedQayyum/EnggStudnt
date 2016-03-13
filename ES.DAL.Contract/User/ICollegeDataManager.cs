using ES.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Contract
{
    public interface ICollegeDataManager
    {
        List<College> GetAllColleges(bool? IsTop = null, string Cities = null, string Ratings = null);
        College GetCollegeDetails(long? collId);
        List<Review> GetCollegeReviews(long? collId);
    }
}
