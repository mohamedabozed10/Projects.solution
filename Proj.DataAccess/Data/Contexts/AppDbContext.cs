using Proj.DataAccess.Data.Repositories.Models.DepartmentModule;
using Proj.DataAccess.Data.Repositories.Models.EmployeeModule;
using System.Reflection;

namespace Proj.DataAccess.Data.Contexts
{
    //الكلاس اللى بيربط الكود بقاعدة البيانات
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)//primary constructor new way
    {
        //old way
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Connection_string");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Department> Departments { get; set; }//department table
        public DbSet<Employee> Employees { get; set; }//department table

    }
}
