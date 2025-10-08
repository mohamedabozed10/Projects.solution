

namespace Proj.DataAccess.Modules
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;//mandatory
        public string  Code { get; set; } =string.Empty;
        public string? Description { get; set; }
    }
}
