using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Motors.Domain.Model;

namespace Web.Motors.Domain.Interface
{
    public interface IAdvertisementService
    {
        Task Save(AdvertisementModel  advertisement);
        Task Delete(AdvertisementModel advertisement);
        Task<IEnumerable<AdvertisementModel>> Select();
    }
}
