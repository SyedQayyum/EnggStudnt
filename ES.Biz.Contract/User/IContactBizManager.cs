using ES.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Biz.Contract
{
    public interface IContactBizManager
    {
        bool ContactUs(ContactVO ObjContactVO);
    }
}
