using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Motors.Domain.Interface;
using Web.Motors.Domain.Model;

namespace Web.Motors.Data.Repository
{
    public class EntityRepository<TModel> : EntityBase, IRepository<TModel> where TModel : BaseModel, new()
    {
        protected readonly DbSet<TModel> DbSet;

        public EntityRepository(
            WebMotorsDbContext db) : base(db)
        {
            DbSet = db.Set<TModel>();
        }

        public virtual async Task Insert(TModel model)
        {
            DbSet.Add(model);
            await SaveChanges();
        }

        public virtual async Task Update(TModel model)
        {
            DbSet.Update(model);
            await SaveChanges();
        }

        public virtual async Task Remove(TModel model)
        {
            DbSet.Remove(model);
            await SaveChanges();
        }
        public virtual async Task<List<TModel>> List()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TModel>> Query(Expression<Func<TModel, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }


    }
}
