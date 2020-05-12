using AutoMapper;
using Web.Motors.Domain.Model;
using Web.Motors.WebAPI.ViewModel;

namespace Web.Motors.WebAPI.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AdvertisementModel, AdvertisementViewModel>().ReverseMap();            
        }
    }
}
