using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Pro.BusinessLogic.DTOS.DepartmentDtos;
using Pro.BusinessLogic.Services.Classes;
using Pro.BusinessLogic.Services.InterFaces;
using Project.Presentation.ViewModels;

namespace Project.Presentation.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentServices
        ,IWebHostEnvironment _env,ILogger<DepartmentController> _logger) : Controller//inherit from controller class to use its features
    //use primary constructor to (new feture in c#) that means the controller will take 3 parameters
    //1-service to deal with department operations
    //2-env to know if the app in development mode or production mode
    //3-logger to log errors if happend
    {
        #region Index
        //take all departments from service and return them to view_index to show them in table
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
        
        public IActionResult Create(CreateEmployeetDto departmentDto)
        {
            //call service to add department
            //if result >0 return to index else show error message
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
                        return View("Error",ex);
                    }
                }
            }
            return View(departmentDto);

           
        }
        #endregion

        #region Details
        //take id from route & return department to view to show details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }
        #endregion

        #region Edit
        //take id from route & return department to view to edit it & send edits to service
        //get department by id and map it to view model to show it in view_edit form
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();//400
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();//404
                                                      //  return View(department);
            var departmentVM = new DepartmentEditViewModel()
            {
              
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = department.CreatedOn.HasValue? department.CreatedOn.Value: default//1/01/0001
            };
            return View(departmentVM);
        }
        [HttpPost]
        //
        public IActionResult Edit([FromRoute]int? id, DepartmentEditViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //buld dto object to send it to service 
                    var departmentDto = new UpdatedDepartmentDto()
                    {
                        Id = id.Value,
                        Code = departmentVM.Code,
                        Name = departmentVM.Name,
                        Description = departmentVM.Description,
                        DateOfCreation = departmentVM.CreatedOn
                    };
                    var result = _departmentServices.UpdateDepartment(departmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Deprtment can not be updated !!");//Error Message
                        return View(departmentVM);
                    }
                }
                catch(Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"department can not be created bacua :{ex.Message}");
                    }
                    else
                    {
                        //user error
                        _logger.LogError($"department can not be created bacua ::{ex}");
                        return View("ErrorView",ex);
                    }
                }
            }
            return View(departmentVM);

        }
        #endregion

        #region Delete
        //Get ==> Render the view that contain the details
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentServices.GetDepartmentById(id.Value);
        //    if (department is null) return NotFound();
        //    return View(department);
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id==0) return BadRequest();
            try
            {
                bool IsDeleted = _departmentServices.DeleteDepartment(id);
                if (IsDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Deprtment can not be Deleted !!");//Error Message
                    return RedirectToAction(nameof(Delete),new {id});
                }
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"department can not be Deleted bacua :{ex.Message}");
                }
                else
                {
                    //user error
                    _logger.LogError($"department can not be Deleted bacua ::{ex}");
                    return View("ErrorView", ex);
                }
            }
            return RedirectToAction(nameof(Delete), new { id });
        }
        #endregion



    }
}
