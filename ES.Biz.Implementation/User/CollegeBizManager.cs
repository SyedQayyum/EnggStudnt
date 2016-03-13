using Core.Common;
using ES.Biz.Contract;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ES.Biz.Implementation
{
    public class CollegeBizManager : ICollegeBizManager
    {
        private readonly ICollegeDataManager _collegeDataManager;
        private readonly ICommonBizManager _commonBizManager;


        public CollegeBizManager(ICollegeDataManager collegeDataManager)
        {
            _collegeDataManager = collegeDataManager;
            AppHelper.CreateMap<CollegeVO, College>();
            AppHelper.CreateMap<ReviewVO, Review>();
            _commonBizManager = new CommonBizManager();
        }

        public List<CollegeVO> GetAllColleges(bool? IsTop = null, string Cities = null, string Ratings = null)
        {

            string XmlRatings = Ratings != null ? _commonBizManager.BuildXmlString("Ratings", "Rating", Ratings.Split('$')) : null;
            string XmlCities = Cities != null ? _commonBizManager.BuildXmlString("Cities", "City", Cities.Split('$')) : null;
            var a = _collegeDataManager.GetAllColleges(IsTop, XmlCities, XmlRatings);
            return Mapper.Map<List<College>, List<CollegeVO>>(_collegeDataManager.GetAllColleges(IsTop, XmlCities, XmlRatings));
        }

        public CollegeVO GetCollegeDetails(long? collId)
        {
            return Mapper.Map<College, CollegeVO>(_collegeDataManager.GetCollegeDetails(collId));
        }
        public List<ReviewVO> GetCollegeReviews(long? collId)
        {
            return Mapper.Map<List<Review>, List<ReviewVO>>(_collegeDataManager.GetCollegeReviews(collId));

        }
    }
}
