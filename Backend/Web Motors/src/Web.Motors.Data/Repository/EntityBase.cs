using Web.Motors.Data;

namespace Web.Motors.Data.Repository
{
    public class EntityBase
    {
        protected readonly WebMotorsDbContext Db;

        public EntityBase(WebMotorsDbContext dbContext)
        {
            Db = dbContext;
        }
    }
}
