using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Contract
{
    public interface ISubjectBizManager
    {
        List<KeyValueVO> GetRelatedSubjectsBySubId(int subId);
        List<SubjectVO> GetAllSubjects(int? subId, int? semId, int? deptId);
    }
}
