using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Web.Motors.WebAPI.Configuration
{
    public static class JsonConfig
    {
        public static IServiceCollection AddCustomJson(this IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.Formatting = Formatting.None;
                    if (opt.SerializerSettings.ContractResolver != null)
                    {
                        var resolver = opt.SerializerSettings.ContractResolver as DefaultContractResolver;
                        resolver.NamingStrategy = null;
                    }
                }
                );
            return services;
        }
    }
}
