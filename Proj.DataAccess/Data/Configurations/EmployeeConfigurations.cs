
using Proj.DataAccess.Data.Repositories.Models.EmployeeModule;
using Proj.DataAccess.Data.Repositories.Models.Shared;

namespace Proj.DataAccess.Data.Configurations
{
    class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Adress).HasColumnType("varchar(50)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.ModefiedOn).HasComputedColumnSql("GETDATE()");
            builder.Property(e => e.Gender).HasConversion((empgender) => empgender.ToString()//from app to DB
             , (gender) => (Gender)Enum.Parse(typeof(Gender), gender));
            builder.Property(e => e.EmployeeType).HasConversion((emptype) => emptype.ToString()//from app to DB
             , (employeetype) => (EmployeeType)Enum.Parse(typeof(EmployeeType), employeetype));
        }
    }
}
