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
    public class OperatorBizManager : IOperatorBizManager
    {
        private readonly IOperatorDataManager _operatorDataManager;

        public OperatorBizManager(IOperatorDataManager operatorDataManager)
        {
            _operatorDataManager = operatorDataManager;
            AppHelper.CreateMap<OperatorVO, Operator>();
        }

        public int CreateOperator(OperatorVO ObjOperatorVO)
        {
            return _operatorDataManager.CreateOperator(Mapper.Map<OperatorVO, Operator>(ObjOperatorVO));
        }
    }
}