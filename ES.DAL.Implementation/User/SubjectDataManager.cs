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
    public class SubjectDataManager : ISubjectDataManager
    {
        public List<KeyValue> GetRelatedSubjectsBySubId(int subId)
        {

            SqlConnection con = new ESDbContext().GetConnection();
            List<KeyValue> objSubjectList = new List<KeyValue>();
            int ReturnValue = 1;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
			       new SqlParameter("@subId",subId)
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdSubjects = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetRelatedSubjectsBySubId", Params);

            while (rdSubjects.Read())
            {
                objSubjectList.Add(

                    new KeyValue()
                    {
                        Id = Convert.ToInt32(rdSubjects["subId"].ToString()),
                        Name = rdSubjects["subName"].ToString(),
                    });
            }
            rdSubjects.Close();
            //ReturnValue = Convert.ToInt16(rdAdvertisement.Parameters["@EmpName"].Value.Value.ToString()); // Get Return value to check errors in DB
            con.Close();
            if (ReturnValue < 0)
            {
                return null;
            }

            return objSubjectList;
        }

        public List<KeyValue> GetAllSubjects(int? subId, bool? isDeleted)
        {

            SqlConnection con = new ESDbContext().GetConnection();
            List<KeyValue> objSubjectList = new List<KeyValue>();
            int ReturnValue = 1;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
			       subId != null ? new SqlParameter("@subId",subId) : new SqlParameter("@subId",DBNull.Value),
                  isDeleted!=null? new SqlParameter("@isDeleted",isDeleted) : new SqlParameter("@isDeleted",DBNull.Value)
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdSubjects = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetAllSubject", Params);

            while (rdSubjects.Read())
            {
                objSubjectList.Add(

                    new KeyValue()
                    {
                        Id = Convert.ToInt32(rdSubjects["subId"].ToString()),
                        Name = rdSubjects["subName"].ToString(),
                    });
            }
            rdSubjects.Close();
            //ReturnValue = Convert.ToInt16(rdAdvertisement.Parameters["@EmpName"].Value.Value.ToString()); // Get Return value to check errors in DB
            con.Close();
            if (ReturnValue < 0)
            {
                return null;
            }

            return objSubjectList;
        }

        public List<Subject> GetAllSubjects(int? subId, int? semId, int? deptId)
        {
            SqlConnection con = new ESDbContext().GetConnection();
            List<Subject> objSubjectList = new List<Subject>();
            int ReturnValue = 1;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
			       subId != null ? new SqlParameter("@subId",subId) : new SqlParameter("@subId",DBNull.Value),
                   semId!=null? new SqlParameter("@semId",semId) : new SqlParameter("@semId",DBNull.Value),
                   deptId!=null? new SqlParameter("@deptId",deptId) : new SqlParameter("@deptId",DBNull.Value) 
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdSubjects = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetAllSubject", Params);

            while (rdSubjects.Read())
            {
                objSubjectList.Add(

                    new Subject()
                    {
                        id = Convert.ToInt32(rdSubjects["subId"].ToString()),
                        subName = rdSubjects["subName"].ToString(),
                        deptName = rdSubjects["deptName"].ToString(),
                        semId = Convert.ToInt32(rdSubjects["semId"].ToString()),
                        semName = rdSubjects["semName"].ToString(),
                        deptId = Convert.ToInt32(rdSubjects["deptId"].ToString()),

                    });
            }
            rdSubjects.Close();
            //ReturnValue = Convert.ToInt16(rdAdvertisement.Parameters["@EmpName"].Value.Value.ToString()); // Get Return value to check errors in DB
            con.Close();
            if (ReturnValue < 0)
            {
                return null;
            }

            return objSubjectList;
        }
    }
}
