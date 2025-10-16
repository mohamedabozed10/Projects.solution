

namespace Proj.DataAccess.Data.Repositories.BaseInterface
{
   public interface IBaseRepository<T> where T : class
   {
        int Add(T entity);
        IEnumerable<T> GetAll(bool withTracking = false);
        T? GetById(int id);
        int Remove(T entity);
        int Update(T entity);
   }
}
