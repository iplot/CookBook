using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.Interfaces;

namespace CookBook.DbLayer.DataBase
{
    internal class RepositoryBase<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<T> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(GetPropertyName(include)));
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public T GetEntity(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetEntityAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void AddEntityToContext(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _dbSet.Add(entity);
            }
        }

        public async Task<int> AddEntityAndSubmit(T entity)
        {
			var entry = _context.Entry(entity);
			
			if(entry.State == EntityState.Detached)
			{
				_dbSet.Add(entity);
			}
            
            return await _context.SaveChangesAsync();
        }

        private string GetPropertyName(Expression<Func<T, object>> expression)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression body must be a member expression");
            }

            return memberExpression.Member.Name;
        }
    }
}
