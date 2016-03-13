using AutoMapper;
using Core.Common;
using ES.Biz.Contract;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Implementation
{
    public class SubjectBizManager : ISubjectBizManager
    {

        private readonly ISubjectDataManager _subjectDataManager;

        public SubjectBizManager(ISubjectDataManager subjectDataManager)
        {
            _subjectDataManager = subjectDataManager;
            AppHelper.CreateMap<KeyValueVO, KeyValue>();
            AppHelper.CreateMap<SubjectVO, Subject>();
        }

        public List<KeyValueVO> GetRelatedSubjectsBySubId(int subId)
        {
            List<KeyValueVO> SubjectList = Mapper.Map<List<KeyValue>, List<KeyValueVO>>(_subjectDataManager.GetRelatedSubjectsBySubId(subId));
            return SubjectList;
        }

        public List<SubjectVO> GetAllSubjects(int? subId, int? semId, int? deptId)
        {
            return Mapper.Map<List<Subject>, List<SubjectVO>>(_subjectDataManager.GetAllSubjects(subId, semId, deptId));
        }

    }
}
