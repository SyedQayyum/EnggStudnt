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
    public class DepartmentBizManager : IDepartmentBizManager
    {
        private readonly IDepartmentDataManager _departmentDataManager;

        public DepartmentBizManager(IDepartmentDataManager departmentDataManager)
        {
            _departmentDataManager = departmentDataManager;
            AppHelper.CreateMap<DepartmentVO, Department>();
        }
        public List<DepartmentVO> GetAllDepartments()
        {
            return Mapper.Map<List<Department>, List<DepartmentVO>>(_departmentDataManager.GetAllDepartments());
        }
    }
}
