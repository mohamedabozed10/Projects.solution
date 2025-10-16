using Proj.DataAccess.Data.Contexts;
using Proj.DataAccess.Data.Repositories.Interfaces;
using Proj.DataAccess.Data.Repositories.Models.DepartmentModule;

namespace Proj.DataAccess.Data.Repositories.Classes
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    
    }
}
