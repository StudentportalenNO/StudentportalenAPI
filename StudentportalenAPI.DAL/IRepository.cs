using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentportalenAPI.DAL
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        Task<TEntity> GetByIdAsync(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}