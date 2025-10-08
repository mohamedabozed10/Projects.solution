using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Pro.BusinessLogic.DTOS;
using Pro.BusinessLogic.Services.Classes;
using Pro.BusinessLogic.Services.InterFaces;

namespace Project.Presentation.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentServices
        ,IWebHostEnvironment _env,ILogger<DepartmentController> _logger) : Controller
    {
        #region Index
        public IActionResult Index()
        {
            var department = _departmentServices.GetAllDepartments();
            return View(department);
        }
        #endregion
        #region Create
        //Return View
     
        public IActionResult Create()
        {
            return View();//Some Name like Create
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _departmentServices.AddDepartment(departmentDto);

                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Something Went Wrong !!");//Error Message

                    }
                }

                catch (Exception ex)
                {
                    //devoloper error
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError(ex, "An error occurred while creating a department.");

                    }
                    else
                    {
                        //user error
                        _logger.LogError(ex, "An error occurred while creating a department.");
                        return View("Error");
                    }
                }
            }
            return View(departmentDto);

           
        }
        #endregion
        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }
        #endregion
    }
}
