using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Web.Motors.Domain.Interface;
using Web.Motors.Service;
using Web.Motors.Data;
using Web.Motors.Infrastructure.Notifiers;

namespace Web.Motors.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<WebMotorsDbContext>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();            
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
