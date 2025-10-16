using Microsoft.EntityFrameworkCore;
using Proj.DataAccess.Data.Contexts;
using Proj.DataAccess.Data.Repositories.BaseInterface;


namespace Proj.DataAccess.Data.Repositories.Classes
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T? GetById(int id) => _dbContext.Set<T>().Find(id);

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _dbContext.Set<T>().ToList();
            else
                return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
