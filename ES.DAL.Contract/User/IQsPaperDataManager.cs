using ES.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.Contract
{
    public interface IQsPaperDataManager
    {
        QsPaper GetQsPaperByHeading(string QsHeading = null, int? SubId = null, int? PageOrder = null);
        List<QsPaper> GetQsPaperYearBySubjectId(int subjectId);
    }
}
