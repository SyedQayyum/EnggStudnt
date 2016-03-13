using ES.DAL.Model;
using System.Collections.Generic;
using System.Data;

namespace ES.DAL.Contract
{
    public interface IAdvertisementDataManager
    {
        List<Advertisement> GetAdvertisements(string Url);
    }
}
