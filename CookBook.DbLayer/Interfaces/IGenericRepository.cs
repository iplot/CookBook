using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DbLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        IQueryable<T> GetEntities(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        T GetEntity(int id);
        Task<T> GetEntityAsync(int id);
        void AddEntityToContext(T entity);
        Task<int> AddEntityAndSubmit(T entity);
    }
}
