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
    public class DepartmentDataManager : IDepartmentDataManager
    {
        public List<Department> GetAllDepartments()
        {

            ESDbContext con = new ESDbContext();
            List<Department> DepartmentList = new List<Department>();
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdDepartment = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetAllDepartment", Params);

            while (rdDepartment.Read())
            {
                DepartmentList.Add(
                    new Department()
                    {
                        id = Convert.ToInt32(rdDepartment["deptId"].ToString()),
                        deptName = rdDepartment["deptName"].ToString(),
                        deptAbbrName = rdDepartment["deptAbbreviation"].ToString(),
                    });
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return DepartmentList;
            }

            return DepartmentList;
        }
    }
}
