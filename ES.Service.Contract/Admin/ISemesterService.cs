﻿using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Service.Contract
{
   public interface ISemesterService
    {
       List<KeyValueVO> GetAllSemesters();
    }
}
