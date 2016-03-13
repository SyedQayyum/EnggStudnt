using Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Common;
using ES.DAL.Contract;
using ES.DAL.Model;

namespace ES.DAL.Implementation
{
    public class QsPaperDataManager : IQsPaperDataManager
    {
        public QsPaper GetQsPaperByHeading(string QsHeading = null, int? SubId = null, int? PageOrder = null)
        {
            ESDbContext con = new ESDbContext();
            QsPaper dsQsPaper = null;
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                   QsHeading != null ? new SqlParameter("@QsHeading", QsHeading) : new SqlParameter("@QsHeading", DBNull.Value),
                   SubId != null ? new SqlParameter("@subId", SubId) : new SqlParameter("@subId", DBNull.Value),
                   PageOrder != null ? new SqlParameter("@qsPageOrder", PageOrder) : new SqlParameter("@qsPageOrder", DBNull.Value),
			       new SqlParameter("@isDeleted",(int)ApplicationEnums.Answer.No),
			       new SqlParameter("@isPublished",(int)ApplicationEnums.Answer.Yes),

			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdQsPaper = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetQuestionPapers", Params);

            while (rdQsPaper.Read())
            {
                dsQsPaper =
                    new QsPaper()
                    {
                        qsId = Convert.ToInt32(rdQsPaper["qsId"].ToString()),
                        subId = Convert.ToInt32(rdQsPaper["subId"].ToString()),
                        qsPageOrder = Convert.ToInt32(rdQsPaper["qsPageOrder"].ToString()),
                        qsContentRegular = rdQsPaper["qsContentRegular"].ToString(),
                        qsContentSupplementary = rdQsPaper["qsContentSupplementary"].ToString(),
                        qsHeading = rdQsPaper["qsHeading"].ToString(),
                    };
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return dsQsPaper;
            }

            return dsQsPaper;
        }

        public List<QsPaper> GetQsPaperYearBySubjectId(int subjectId)
        {
            ESDbContext con = new ESDbContext();
            List<QsPaper> QsPaperList = new List<QsPaper>();
            int ReturnValue = 0;
            SqlParameter[] Params = 
			{ 
                   new SqlParameter("@opReturnValue", SqlDbType.Int),
                   new SqlParameter("@subId",subjectId)
			};

            Params[0].Direction = ParameterDirection.Output;
            SqlDataReader rdQsPaper = SqlHelper.ExecuteReader(con.GetConnection(), CommandType.StoredProcedure, "USP_GetQsPaperYearBySubjectId", Params);

            while (rdQsPaper.Read())
            {
                QsPaperList.Add(
                    new QsPaper()
                    {
                        qsId = Convert.ToInt32(rdQsPaper["qsId"].ToString()),
                        subId = Convert.ToInt32(rdQsPaper["subId"].ToString()),
                        qsYear = Convert.ToInt32(rdQsPaper["qsYear"].ToString()),
                        qsHeading = rdQsPaper["qsHeading"].ToString(),
                    });
            }
            //ReturnValue = Convert.ToInt16(Params[0].Value.ToString()); // Get Return value to check errors in DB
            if (ReturnValue > 0)
            {
                return QsPaperList;
            }

            return QsPaperList;
        }

    }
}
