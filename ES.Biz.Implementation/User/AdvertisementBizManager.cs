using AutoMapper;
using Core.Common;
using ES.Biz.Contract;
using ES.DAL.Contract;
using ES.DAL.Model;
using ES.ValueObjects;
using System.Collections.Generic;
using System.Data;

namespace ES.Biz.Implementation
{
    public class AdvertisementBizManager : IAdvertisementBizManager
    {
        private readonly IAdvertisementDataManager _advertisementDataManager;

        public AdvertisementBizManager(IAdvertisementDataManager advertisementDataManager)
        {
            _advertisementDataManager = advertisementDataManager;
            AppHelper.CreateMap<AdvertisementVO, Advertisement>();
        }

        public List<AdvertisementVO> GetAdvertisements(string Url)
        {

            List<AdvertisementVO> AdvertismentList = Mapper.Map<List<Advertisement>, List<AdvertisementVO>>(_advertisementDataManager.GetAdvertisements(Url));
            return AdvertismentList;
        }
    }
}
