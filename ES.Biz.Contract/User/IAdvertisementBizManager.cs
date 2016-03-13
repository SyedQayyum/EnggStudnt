using ES.ValueObjects;
using System.Collections.Generic;
using System.Data;

namespace ES.Biz.Contract
{
   public interface IAdvertisementBizManager
    {
       List<AdvertisementVO> GetAdvertisements(string Url);
    }
}
