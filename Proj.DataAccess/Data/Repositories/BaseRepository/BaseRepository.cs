using Microsoft.EntityFrameworkCore;
using Proj.DataAccess.Data.Contexts;
using Proj.DataAccess.Data.Repositories.BaseInterface;
using Proj.DataAccess.Data.Repositories.Models.Shared; // لازم علشان يشوف BaseEntity

namespace Proj.DataAccess.Data.Repositories.Classes
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity // ✅ التعديل هنا
    {
        protected readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T? GetById(int id)
        {
            return _dbContext.Set<T>()
                             .FirstOrDefault(entity => entity.Id == id && !entity.IsDeleted);
        }

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _dbContext.Set<T>()
                                 .Where(entity => !entity.IsDeleted)
                                 .ToList();
            else
                return _dbContext.Set<T>()
                                 .Where(entity => !entity.IsDeleted)
                                 .AsNoTracking()
                                 .ToList();
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
            // ❗ بدل الحذف الفعلي بحذف منطقي
            entity.IsDeleted = true;
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
