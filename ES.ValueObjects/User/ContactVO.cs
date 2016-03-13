using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
    public class ContactVO
    {
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderMessage { get; set; }
        public bool isAdvertise { get; set; }
        public string ContactNumber { get; set; }
        public string OrgazinationName { get; set; }
    }
}
