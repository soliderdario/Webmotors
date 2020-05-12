using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web.Motors.Data;

namespace Web.Motors.WebAPI.Configuration
{
    public static class EntityFrameworkConfig
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, string connectionstring)
        {            
            services.AddDbContext<WebMotorsDbContext>(options =>
            {
                options.UseSqlServer(connectionstring);
            });
            return services;
        }
    }
}
