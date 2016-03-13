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
    public class SyllabusBizManager : ISyllabusBizManager
    {
        private readonly ISyllabusDataManager _syllabusDataManager;

        public SyllabusBizManager(ISyllabusDataManager syllabusDataManager)
        {
            _syllabusDataManager = syllabusDataManager;
            AppHelper.CreateMap<SyllabusVO, Syllabus>();
        }

        public SyllabusVO GetSyllabusByHeading(string syllabusHeading = null, int? SubId = null, int? PageOrder = null)
        {
            return Mapper.Map<Syllabus, SyllabusVO>(_syllabusDataManager.GetSyllabusByHeading(syllabusHeading, SubId, PageOrder));
        }

    }
}
