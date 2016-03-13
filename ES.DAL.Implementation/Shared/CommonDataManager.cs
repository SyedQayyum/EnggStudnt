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
    public class CommonDataManager : ICommonDataManager
    {
        public List<KeyValue> GetAllCities()
        {

            ESDbContext con = new ESDbContext();
            List<KeyValue> CityList = new List<KeyValue>();
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdCity = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetAllCity", Params);

            while (rdCity.Read())
            {
                CityList.Add(
                    new KeyValue()
                    {
                        Id = Convert.ToInt32(rdCity["cityId"].ToString()),
                        Name = rdCity["cityName"].ToString(),
                    });
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return CityList;
            }

            return CityList;
        }
    }
}
