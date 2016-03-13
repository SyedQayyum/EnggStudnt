using ES.Biz.Contract;
using ES.Service.Contract;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Implementation
{
    public class QsPaperService : IQsPaperService
    {
        private readonly IQsPaperBizManager _qsPaperBizManager;
        public QsPaperService(IQsPaperBizManager qsPaperBizManager)
        {
            _qsPaperBizManager = qsPaperBizManager;
        }

        public QsPaperVO GetQsPaperByHeading(string QsHeading = null, int? SubId = null, int? PageOrder = null)
        {
            return _qsPaperBizManager.GetQsPaperByHeading(QsHeading, SubId, PageOrder);
        }

        public List<QsPaperVO> GetQsPaperYearBySubjectId(int subjectId)
        {
            return _qsPaperBizManager.GetQsPaperYearBySubjectId(subjectId);
        }
       
    }
}
