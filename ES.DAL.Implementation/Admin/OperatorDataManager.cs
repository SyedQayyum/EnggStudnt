using Core.Common;
using ES.DAL.Contract;
using ES.DAL.Implementation;
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
    public class OperatorDataManager : IOperatorDataManager
    {
        public int CreateOperator(Operator ObjOperator)
        {
            ESDbContext con = new ESDbContext();
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                   new SqlParameter("@opId",ObjOperator.id),
			       new SqlParameter("@opFisrtName",ObjOperator.opFisrtName),
			       new SqlParameter("@opLastName",ObjOperator.opLastName),
			       new SqlParameter("@opEmail",ObjOperator.opEmail),
			       new SqlParameter("@opPassword",ObjOperator.opPassword),
                   new SqlParameter("@opCreatedBy",ObjOperator.createdBy),
                   new SqlParameter("@opModifiedBy",ObjOperator.modifiedBy),
			};
            Params[0].Direction = ParameterDirection.Output;
            int RecordId = (int)SqlHelper.ExecuteScalar(con.GetConnection(), CommandType.StoredProcedure, "USP_InsertUpdateOperator", Params);
            ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                ReturnValue = RecordId;
            }

            return ReturnValue;
        }
    }
}
