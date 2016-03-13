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
    public class UniversityDataManager : IUniversityDataManager
    {
        public List<University> GetAllUniversities()
        {
            SqlConnection con = new ESDbContext().GetConnection();
            List<University> objUniversityList = new List<University>();
            int ReturnValue = 1;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
			      
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdUniversities = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetAllUniversities", Params);

            while (rdUniversities.Read())
            {
                objUniversityList.Add(

                    new University()
                    {

                        id = Convert.ToInt32(rdUniversities["universityId"].ToString()),
                        universityName = rdUniversities["universityName"].ToString(),
                        universityAbbr = rdUniversities["universityAbbr"].ToString(),
                    });
            }
            rdUniversities.Close();
            //ReturnValue = Convert.ToInt16(rdAdvertisement.Parameters["@EmpName"].Value.Value.ToString()); // Get Return value to check errors in DB
            con.Close();
            if (ReturnValue < 0)
            {
                return null;
            }

            return objUniversityList;
        }
    }
}
