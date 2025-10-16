using Proj.DataAccess.Data.Repositories.Models.Shared;

namespace Proj.DataAccess.Data.Repositories.Models.EmployeeModule
{
    public class Employee :BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Adress { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        //Gender==>(Enum[Male,Female])
        //EmployeeType==>(FullTime,PartTime)
        public EmployeeType EmployeeType { get; set; } //enum
        public Gender Gender { get; set; }

    }
}
