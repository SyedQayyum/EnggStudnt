using Core.Common;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.DAL.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Implementation
{
    public class BranchesDataManager : IBranchesDataManager
    {
        public List<Branches> GetAllBranches()
        {

            bool? isDeleted = null;

            SqlConnection con = new ESDbContext().GetConnection();
            List<Branches> objBranchesList = new List<Branches>();
            int ReturnValue = 1;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                  isDeleted!=null? new SqlParameter("@isDeleted",isDeleted) : new SqlParameter("@isDeleted",DBNull.Value)
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdBranches = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetAllBranches", Params);

            while (rdBranches.Read())
            {
                objBranchesList.Add(

                    new Branches()
                    {
                        id = Convert.ToInt32(rdBranches["branchId"].ToString()),
                        branchAbbr = rdBranches["branchAbbr"].ToString(),
                        branchName = rdBranches["branchName"].ToString()
                    });
            }
            rdBranches.Close();
            //ReturnValue = Convert.ToInt16(rdAdvertisement.Parameters["@EmpName"].Value.Value.ToString()); // Get Return value to check errors in DB
            con.Close();
            if (ReturnValue < 0)
            {
                return null;
            }

            return objBranchesList;
        }
    }
}
