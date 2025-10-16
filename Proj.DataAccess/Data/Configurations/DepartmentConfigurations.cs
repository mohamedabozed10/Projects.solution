


using Proj.DataAccess.Data.Repositories.Models.DepartmentModule;

namespace Proj.DataAccess.Data.Configurations
{
    //كلاس الكونفيجريشن بيحدد ازاى هيكون شكل الجدول فى قاعدة البيانات
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.ModefiedOn).HasComputedColumnSql("GETDATE()");
        }

    }
}
