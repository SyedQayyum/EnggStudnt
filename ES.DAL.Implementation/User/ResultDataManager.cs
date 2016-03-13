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
    public class ResultDataManager : IResultDataManager
    {
        public List<Result> GetAllResults()
        {
            ESDbContext con = new ESDbContext();
            List<Result> ResultList = new List<Result>();
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdResult = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetAllResults", Params);

            while (rdResult.Read())
            {
                ResultList.Add(
                    new Result()
                    {
                        id = Convert.ToInt32(rdResult["resultId"].ToString()),
                        resultHeading = rdResult["resultHeading"].ToString(),
                        resultLink = rdResult["resultLink"].ToString(),
                        resultDate = Convert.ToDateTime(rdResult["resultDate"].ToString()),

                    });
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return ResultList;
            }

            return ResultList;
        }
    }
}
