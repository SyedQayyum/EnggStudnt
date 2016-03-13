using Core.Common;
using ES.Common;
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
    public class AdvertisementDataManager : IAdvertisementDataManager
    {
        public List<Advertisement> GetAdvertisements(string Url)
        {

            SqlConnection con = new ESDbContext().GetConnection();
            List<Advertisement> objAdvertisementList = new List<Advertisement>();
            int ReturnValue = 1;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                   new SqlParameter("@pageUrl",Url),
			       new SqlParameter("@isDeleted",(int)ApplicationEnums.Answer.No),
			       new SqlParameter("@isPublished",(int)ApplicationEnums.Answer.Yes)
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdAdvertisement = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetActiveAdvertisement", Params);

            while (rdAdvertisement.Read())
            {
                objAdvertisementList.Add(

                    new Advertisement()
                    {
                        advPlaceHolderId = rdAdvertisement["advPlaceHolderId"].ToString(),
                        advContent = rdAdvertisement["advContent"].ToString(),
                        advDestinationUrl = rdAdvertisement["advDestinationUrl"].ToString(),
                    });
            }
            rdAdvertisement.Close();
            //ReturnValue = Convert.ToInt16(rdAdvertisement.Parameters["@EmpName"].Value.Value.ToString()); // Get Return value to check errors in DB
            con.Close();
            if (ReturnValue < 0)
            {
                return null;
            }

            return objAdvertisementList;
        }
    }
}
