using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Contract
{
    public interface IQsPaperService
    {
        QsPaperVO GetQsPaperByHeading(string QsHeading = null, int? SubId = null, int? PageOrder = null);
        List<QsPaperVO> GetQsPaperYearBySubjectId(int subjectId);
    }
}
