
using ES.ValueObjects;
using System.Collections.Generic;
using System.Data;

namespace ES.Service.Contract
{
    public interface IAdvertisementService
    {
        List<AdvertisementVO> GetAdvertisements(string Url);
    }
}
