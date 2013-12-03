using System;
using System.Data.Entity;
using System.Threading.Tasks;
using StudentportalenAPI.DAL.Configuration.Entityframework;

namespace StudentportalenAPI.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _context;

        public UnitOfWork()
        {
            _context = new StudentportalenAPIDbContext();
        }

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //private Repository<Article> _articleRepository;

        //public Repository<Article> ArticleRepository
        //{
        //    get { return _articleRepository ?? (_articleRepository = new Repository<Article>(_context)); }
        //}
    }
}