using ES.Biz.Contract;
using ES.Service.Contract;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectBizManager _subjectBizManager;

        public SubjectService(ISubjectBizManager subjectBizManager)
        {
            _subjectBizManager = subjectBizManager;
        }


        public List<KeyValueVO> GetRelatedSubjectsBySubId(int subId)
        {
            return _subjectBizManager.GetRelatedSubjectsBySubId(subId);
        }

        public List<KeyValueVO> GetAllSubjects(int? subId, bool? isDeleted)
        {
            return _subjectBizManager.GetAllSubjects(subId, isDeleted);
        }
    }
}
