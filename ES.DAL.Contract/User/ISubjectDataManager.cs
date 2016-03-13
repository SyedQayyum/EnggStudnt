using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.DAL.Model;

namespace ES.DAL.Contract
{
    public interface ISubjectDataManager
    {
        List<KeyValue> GetRelatedSubjectsBySubId(int subId);
        List<KeyValue> GetAllSubjects(int? subId, bool? isDeleted);
        List<Subject> GetAllSubjects(int? subId, int? semId, int? deptId);
    }
}
