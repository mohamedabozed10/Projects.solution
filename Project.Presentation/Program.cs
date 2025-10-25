using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pro.BusinessLogic.Services.Classes;
using Pro.BusinessLogic.Services.InterFaces;
using Proj.DataAccess.Data.Contexts;
using Proj.DataAccess.Data.Repositories.Classes;
using Proj.DataAccess.Data.Repositories.Interfaces;

namespace Project.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);//create the app builder to prapair settings and services and DI & server building

            #region DI Container
            // Add services to the container.
            builder.Services.AddControllersWithViews();//to use MVC
                                                       //Add DbContext to the DI Container 
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly("Proj.DataAccess") 
                );
                options.UseLazyLoadingProxies();//to enable lazy loading
            });

            //Dependency Injection for Repositories and Service 
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();//يعنى لما حد يطلب الانترفيس اديله نسخه من الكلاس 
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeServices>();
            builder.Services.AddAutoMapper(auto=> { },typeof(EmployeeServices).Assembly);//to use automapper in the project
            #endregion

            var app = builder.Build();//build the app after configuring it

            // Configure the HTTP request pipeline.
            //if app not in development mode show detailed error page
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            #region pipes that requests move in 
            app.UseHttpsRedirection();//when http request comes it will be redirected to https
            app.UseStaticFiles(); //to use static files like css,js,images
            app.UseRouting();     //to route the request to the correct controller and action method
            app.UseAuthorization();//to authorize the user
            #endregion

            //بيحدد المسار اللي هيتم من خلاله الوصول للكنترولر والاكنشن
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();//server strats to listen for requests
        }
    }
}
