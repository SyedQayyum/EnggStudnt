using ES.Service.Contract;
using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Implementation
{
    public class SemesterService : ISemesterService
    {
        public List<KeyValueVO> GetAllSemesters()
        {
             List<KeyValueVO> SemesterList = new List<KeyValueVO>();
             return SemesterList;
        }
    }
}
