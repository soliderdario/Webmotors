using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Motors.Data;
using Web.Motors.Data.Repository;
using Web.Motors.Domain.Interface;
using Web.Motors.Domain.Model;
using Web.Motors.Domain.Types;
using Web.Motors.Infrastructure.Notifiers;

namespace Web.Motors.Service
{
    public class AdvertisementService :EntityRepository<AdvertisementModel>, IAdvertisementService
    {
        private readonly INotifier _notifier;       
        public AdvertisementService(
            INotifier notifier,
            WebMotorsDbContext db) : base(db)
        {
            _notifier = notifier;          
        }

        public async Task Delete(AdvertisementModel advertisement)
        {
            await base.Remove(advertisement);
        }

        private void Validation(AdvertisementModel advertisement)
        {
            if (Query(src => src.Marca == advertisement.Marca &&  src.Modelo != advertisement.Modelo && src.Id != advertisement.Id).Result.Any())
            {
                _notifier.SetNotification(new Notification("Já existe um anúncio cadastrado com essa marca e modelo."));
                return;
            }
        }

        public async Task Save(AdvertisementModel advertisement)
        {
            Validation(advertisement);
            if (_notifier.HasNotification())
            {
                return;
            }
            if (advertisement.Operation == OperationType.Insert)
            {
                await base.Insert(advertisement);
            }
            else
            {
                await base.Update(advertisement);
            }
        }

        public async Task<IEnumerable<AdvertisementModel>> Select()
        {
            return await base.List();
        }
    }
}
