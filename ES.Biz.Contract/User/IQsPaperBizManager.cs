using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Contract
{
   public interface IQsPaperBizManager
    {
       QsPaperVO GetQsPaperByHeading(string QsHeading = null, int? SubId = null, int? PageOrder = null);
       List<QsPaperVO> GetQsPaperYearBySubjectId(int subjectId);
    }
}
