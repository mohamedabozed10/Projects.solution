using Proj.DataAccess.Data.Contexts;
using Proj.DataAccess.Data.Repositories.Interfaces;

namespace Proj.DataAccess.Data.Repositories.Classes
{
    public class DepartmentRepository(AppDbContext _dbContext) : IDepartmentRepository
    //New Way
    {
        #region Old_Way
        //private readonly AppDbContext _dbContext;
        //Ask CLR To Create Object From AppDbContext Class
        //public DepartmentRepository(AppDbContext dbcontext)//[1] Dependency Injection (step 1)
        //{
        //    _dbContext = dbcontext;
        //} 
        #endregion
        //5CRUD oPERATIONS
        //[1-GetById]
        public Department? GetById(int id) => _dbContext.Departments.Find(id);
        //[2-GetAll]
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();
        }
        //[3-Add]
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
        //[4-Update]
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();//number of rows affected
        }
        //[5-Delete]
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }


    }
}
