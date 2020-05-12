using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Motors.Domain.Model;

namespace Web.Motors.Domain.Interface
{
    public interface IRepository<TModel> : IDisposable where TModel : BaseModel
    {
        Task Insert(TModel model);
        Task Update(TModel model);
        Task Remove(TModel model);
        Task<List<TModel>> List();
        Task<IEnumerable<TModel>> Query(Expression<Func<TModel, bool>> predicate);
        Task<int> SaveChanges();
    }
}
