using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ES.Common
{
    public class ApplicationEnums
    {
        public enum Gender
        {
            [EnumMember, Description("Female")]
            Female = 0,
            [EnumMember, Description("Male")]
            Male = 1
        }

        public enum Answer
        {
            [EnumMember, Description("NO")]
            No = 0,
            [EnumMember, Description("YES")]
            Yes = 1
        }
    }
}
