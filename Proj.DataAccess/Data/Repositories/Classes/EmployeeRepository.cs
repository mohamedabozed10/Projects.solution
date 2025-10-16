using Proj.DataAccess.Data.Contexts;
using Proj.DataAccess.Data.Repositories.Interfaces;
using Proj.DataAccess.Data.Repositories.Models.EmployeeModule;

namespace Proj.DataAccess.Data.Repositories.Classes
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
