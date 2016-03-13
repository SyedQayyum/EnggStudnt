using AutoMapper;
using Core.Common;
using ES.Biz.Contract;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Implementation
{
    public class QsPaperBizManager : IQsPaperBizManager
    {
        private readonly IQsPaperDataManager _qsPaperDataManager;

        public QsPaperBizManager(IQsPaperDataManager qsPaperDataManager)
        {
            _qsPaperDataManager = qsPaperDataManager;
            AppHelper.CreateMap<QsPaperVO, QsPaper>();
        }

        public QsPaperVO GetQsPaperByHeading(string QsHeading = null, int? SubId = null, int? PageOrder = null)
        {
            return Mapper.Map<QsPaper, QsPaperVO>(_qsPaperDataManager.GetQsPaperByHeading(QsHeading, SubId, PageOrder));
        }

        public  List<QsPaperVO> GetQsPaperYearBySubjectId(int subjectId)
        {
            return Mapper.Map<List<QsPaper>, List<QsPaperVO>>(_qsPaperDataManager.GetQsPaperYearBySubjectId(subjectId));
        }

    }
}
