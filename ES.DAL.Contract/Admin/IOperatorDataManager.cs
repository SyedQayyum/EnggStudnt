using ES.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Contract
{
   public interface IOperatorDataManager
    {
       int CreateOperator(Operator ObjOperator);
    }
}
