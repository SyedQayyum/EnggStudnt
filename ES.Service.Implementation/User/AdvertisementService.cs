using ES.Biz.Contract;
using ES.Service.Contract;
using ES.ValueObjects;
using System.Collections.Generic;
using System.Data;

namespace ES.Service.Implementation
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementBizManager _advertisementBizManager;
        public AdvertisementService(IAdvertisementBizManager advertisementBizManager)
        {
            _advertisementBizManager = advertisementBizManager;
        }

        public List<AdvertisementVO> GetAdvertisements(string Url)
        {
            return _advertisementBizManager.GetAdvertisements(Url);
        }
    }
}
