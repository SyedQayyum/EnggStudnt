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
    public class SyllabusDataManager : ISyllabusDataManager
    {
        public Syllabus GetSyllabusByHeading(string syllabusHeading = null, int? SubId = null, int? PageOrder = null)
        {
            ESDbContext con = new ESDbContext();
            Syllabus dsSyllabus = null;
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                   syllabusHeading != null ? new SqlParameter("@syllabusHeading", syllabusHeading) : new SqlParameter("@syllabusHeading", DBNull.Value),
                   SubId != null ? new SqlParameter("@subId", SubId) : new SqlParameter("@subId", DBNull.Value),
                   PageOrder != null ? new SqlParameter("@syllabusPageOrder", PageOrder) : new SqlParameter("@syllabusPageOrder", DBNull.Value),
			       new SqlParameter("@isDeleted",(int)ApplicationEnums.Answer.No),
			       new SqlParameter("@isPublished",(int)ApplicationEnums.Answer.Yes),

			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdSyllabus = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetSyllabus", Params);

            while (rdSyllabus.Read())
            {
                dsSyllabus =
                    new Syllabus()
                    {
                        id = Convert.ToInt32(rdSyllabus["syllabusId"].ToString()),
                        subId = Convert.ToInt32(rdSyllabus["subId"].ToString()),
                        semId = Convert.ToInt32(rdSyllabus["semId"].ToString()),
                        syllabusPageOrder = Convert.ToInt32(rdSyllabus["syllabusPageOrder"].ToString()),
                        syllabusContent = rdSyllabus["syllabusContent"].ToString(),
                        syllabusHeading = rdSyllabus["syllabusHeading"].ToString(),
                    };
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return dsSyllabus;
            }

            return dsSyllabus;
        }
    }
}
