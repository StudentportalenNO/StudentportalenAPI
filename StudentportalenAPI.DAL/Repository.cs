using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentportalenAPI.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext Context;
        internal DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }


        public Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            //Code needs to be asyncified!
            /*
              Task<IQueryable<TEntity>> query = DbSet;

            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
             */
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            Context.Entry(entity).State = EntityState.Added;
        }

        public virtual async void Delete(object id)
        {
            Delete(await GetByIdAsync(id));
        }

        public virtual void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}