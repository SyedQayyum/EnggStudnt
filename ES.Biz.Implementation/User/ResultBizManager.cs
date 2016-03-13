using AutoMapper;
using Core.Common;
using ES.Biz.Contract;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.ValueObjects;
using System.Collections.Generic;

namespace ES.Biz.Implementation
{
    public class ResultBizManager : IResultBizManager
    {
        private readonly IResultDataManager _resultDataManager;

        public ResultBizManager(IResultDataManager resultDataManager)
        {
            _resultDataManager = resultDataManager;
            AppHelper.CreateMap<ResultVO, Result>();
        }

        public List<ResultVO> GetAllResults()
        {
            return Mapper.Map<List<Result>, List<ResultVO>>(_resultDataManager.GetAllResults());
        }

    }
}
