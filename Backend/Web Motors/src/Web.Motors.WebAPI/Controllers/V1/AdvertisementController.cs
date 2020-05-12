using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Web.Motors.Infrastructure.Notifiers;
using Web.Motors.Domain.Interface;
using Web.Motors.WebAPI.ViewModel;
using Web.Motors.Domain.Model;

namespace Web.Motors.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdvertisementController : MainController
    {
        private readonly IAdvertisementService _advertisementService;
        public AdvertisementController(
            IAdvertisementService advertisementService,
            INotifier notifier,
            IMapper mapper) : base(notifier, mapper)
        {
            _advertisementService = advertisementService;
        }

        [HttpPost("save")]
        public async Task<ActionResult<AdvertisementViewModel>> Save(AdvertisementViewModel advertisement)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }
                var advertisementtModel = _mapper.Map<AdvertisementModel>(advertisement);
                await _advertisementService.Save(advertisementtModel);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
            return CustomResponse(advertisement);
        }

        [HttpGet("list")]
        public async Task<IEnumerable<AdvertisementViewModel>> List()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<AdvertisementViewModel>>(await _advertisementService.Select());
                return result;
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
                return (IEnumerable<AdvertisementViewModel>)BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var advertisement = _advertisementService.Select().Result?.Where(src => src.Id == Id).FirstOrDefault();
                if (advertisement == null) return NotFound();
                await _advertisementService.Delete(advertisement);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
            return CustomResponse(Id);
        }
    }
}
