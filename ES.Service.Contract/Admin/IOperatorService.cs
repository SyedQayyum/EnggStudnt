using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Contract
{
    public interface IOperatorService
    {
        int CreateOperator(OperatorVO ObjOperatorVO);
    }
}
