using Proj.DataAccess.Data.Repositories.Models.Shared;

namespace Proj.DataAccess.Data.Repositories.Models.DepartmentModule
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;//mandatory
        public string  Code { get; set; } =string.Empty;
        public string? Description { get; set; }
    }
}
