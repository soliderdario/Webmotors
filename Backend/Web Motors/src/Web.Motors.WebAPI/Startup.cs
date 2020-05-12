using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Motors.WebAPI.Configuration;

namespace Web.Motors.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Json Configuration
            services.AddCustomJson();

            //Dependency Injection Configuration
            services.ResolveDependencies();

            //Entity Framework Configuration
            services.AddDbContextConfiguration(Configuration.GetConnectionString("DefaultConnection"));

            //Auto Mapper Configuration
            services.AddAutoMapper(typeof(Startup));

            //Cors to client application
            services.CorsConfiguration();

            //Api Versioning  Configuration
            services.AddApiVersioningCustom();

            //Swagger Configuration
            services.AddApiVersionSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {

            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseApiVersionSwaggerConfiguration(provider);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
