using AutoMapper;
using Core.Common;
using ES.Biz.Contract;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Implementation
{
    public class UniversityBizManager : IUniversityBizManager
    {
        private readonly IUniversityDataManager _universityDataManager;

        public UniversityBizManager(IUniversityDataManager universityDataManager)
        {
            _universityDataManager = universityDataManager;
            AppHelper.CreateMap<UniversityVO, University>();
        }

        public List<UniversityVO> GetAllUniversities()
        {
            List<UniversityVO> UniversityList = Mapper.Map<List<University>, List<UniversityVO>>(_universityDataManager.GetAllUniversities());
            return UniversityList;
        }
    }
}
