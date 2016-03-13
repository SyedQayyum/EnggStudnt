using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Contract
{
    public interface ISubjectService
    {
        List<KeyValueVO> GetRelatedSubjectsBySubId(int subId);
        List<KeyValueVO> GetAllSubjects(int? subId, bool? isDeleted);
    
        
    }
}
