using Core.Common;
using ES.DAL.Contract;
using ES.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Implementation
{
    public class CollegeDataManager : ICollegeDataManager
    {

        public List<College> GetAllColleges(bool? IsTop = null, string Cities = null, string Ratings = null)
        {
            ESDbContext con = new ESDbContext();
            List<College> CollegeList = new List<College>();
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                   IsTop != null ? new SqlParameter("@isTop", IsTop) : new SqlParameter("@isTop", DBNull.Value),
                   Cities != null ? new SqlParameter("@cities", Cities) : new SqlParameter("@cities", DBNull.Value),
                   Ratings != null ? new SqlParameter("@collRatings", Ratings) : new SqlParameter("@collRatings", DBNull.Value),
                   
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdCollege = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetAllColleges", Params);

            while (rdCollege.Read())
            {
                CollegeList.Add(
                    new College()
                    {
                        id = Convert.ToInt32(rdCollege["collId"].ToString()),
                        collUniversity = Convert.ToInt32(rdCollege["universityId"].ToString()),
                        collName = rdCollege["collName"].ToString(),
                        collLogo = rdCollege["collLogo"].ToString(),
                        collRating = Convert.ToInt32(rdCollege["collRating"].ToString()),
                    });
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return CollegeList;
            }

            return CollegeList;
        }

        public College GetCollegeDetails(long? collId)
        {
            ESDbContext con = new ESDbContext();
            College objCollege = new College();
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                   collId != null ? new SqlParameter("@collId", collId) : new SqlParameter("@collId", DBNull.Value),
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdCollege = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetCollegeDetailsById", Params);

            while (rdCollege.Read())
            {
                objCollege =
                    new College()
                    {
                        id = Convert.ToInt32(rdCollege["collId"].ToString()),
                        collUniversity = Convert.ToInt32(rdCollege["universityId"].ToString()),
                        collName = rdCollege["collName"].ToString(),
                        collLogo = rdCollege["collLogo"].ToString(),
                        collRating = Convert.ToInt32(rdCollege["collRating"].ToString()),
                        collAddress = rdCollege["collAddress"].ToString(),
                        collPhone = rdCollege["collPhone"].ToString(),
                        collCity = rdCollege["collCity"].ToString(),
                        collIsTop = Convert.ToBoolean(rdCollege["collIsTop"].ToString()),
                        collWebsite = rdCollege["collWebsite"].ToString(),
                        collFax = rdCollege["collFax"].ToString(),
                        collEmail = rdCollege["collEmail"].ToString(),
                        coursesOffered = rdCollege["coursesOffered"].ToString(),
                        collStablishedYear = rdCollege["collStablishedYear"].ToString(),
                    };
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return objCollege;
            }

            return objCollege;
        }

        public List<Review> GetCollegeReviews(long? collId)
        {
            ESDbContext con = new ESDbContext();
            List<Review> ReviewList = new List<Review>();
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                   collId != null ? new SqlParameter("@collegeId", collId) : new SqlParameter("@collegeId", DBNull.Value),                   
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdReview = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetCollegeReviews", Params);

            while (rdReview.Read())
            {
                ReviewList.Add(
                    new Review()
                    {
                        id = Convert.ToInt32(rdReview["revId"].ToString()),
                        revRating = Convert.ToInt32(rdReview["revRating"].ToString()),
                        revReview = rdReview["revReview"].ToString(),
                        revUserName = rdReview["revUserName"].ToString(),
                    });
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return ReviewList;
            }

            return ReviewList;
        }
    }
}
