using Microsoft.EntityFrameworkCore;
using Web.Motors.Data.Mappings;

namespace Web.Motors.Data
{
    public class WebMotorsDbContext : DbContext
    {

        public WebMotorsDbContext(DbContextOptions<WebMotorsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementModelMapping());
        }
    }
}
