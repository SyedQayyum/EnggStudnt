
using ES.Biz.Contract;
using ES.Service.Contract;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Implementation
{
    public class OperatorService : IOperatorService
    {

        private readonly IOperatorBizManager _operatorBizManager;
        public OperatorService(IOperatorBizManager operatorBizManager)
        {
            _operatorBizManager = operatorBizManager;
        }

        public int CreateOperator(OperatorVO ObjOperatorVO)
        {
            return _operatorBizManager.CreateOperator(ObjOperatorVO);
        }
    }
}
