using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.ValueObjects
{
   public class AdvertisementVO :BaseVO
    {
        public Nullable<int> custId { get; set; }
        public string advPlaceHolderId { get; set; }
        public string advContent { get; set; }
        public string advDestinationUrl { get; set; }
        public Nullable<System.DateTime> advActivationDate { get; set; }
        public Nullable<System.DateTime> advExpiredDate { get; set; }
    }
}
