using Microsoft.Extensions.DependencyInjection;

namespace Web.Motors.WebAPI.Configuration
{
    public static class CorsConfig
    {
        public static IServiceCollection CorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        );


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithOrigins("http://www.webmotors.com.br")
                            .SetIsOriginAllowedToAllowWildcardSubdomains());
            });
            return services;
        }
    }
}
