using Microsoft.AspNetCore.Mvc;
using Pro.BusinessLogic.DTOS.DepartmentDtos;
using Pro.BusinessLogic.DTOS.EmployeeDtos;
using Proj.DataAccess.Data.Repositories.Interfaces;
using Proj.DataAccess.Data.Repositories.Models.EmployeeModule;
using Proj.DataAccess.Data.Repositories.Models.Shared;
using Pro.BusinessLogic.Services.Classes;

namespace Project.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        #region Ctor

        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
            IEmployeeService employeeService,
            IWebHostEnvironment env,
            ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _env = env;
            _logger = logger;
        } 
        #endregion


        #region Index
        //Master Action Method
        [HttpGet]
        public IActionResult Index()
        {
            var employee = _employeeService.GetAllEmployees();
            return View(employee);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(CreateEmployeeDto employeeDto)
        {
            //call service to add employee
            //if result >0 return to index else show error message
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeService.CreateEmployee(employeeDto);

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
                        _logger.LogError(ex, "An error occurred while creating a employee.");

                    }
                    else
                    {
                        //user error
                        _logger.LogError(ex, "An error occurred while creating a employee.");
                        return View("Error", ex);
                    }
                }
            }
            return View(employeeDto);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)  return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            return (employee is null) ? NotFound(): View(employee);    
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            //lets map EmployeeDetailsDto to UpdatedEmployeeDto
            var employeeDto = new UpdatedEmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate= employee.HiringDate,
                Gender=Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
            };
            return View(employeeDto);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdatedEmployeeDto employeeDto) 
        {
            if (!id.HasValue ||id!=employeeDto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(employeeDto);
            try
            {
                var result = _employeeService.UpdateEmployee(employeeDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));

                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can not be updated !!");//Global Error Message
                    return View(employeeDto);
                }
            }
            catch (Exception ex)
            {
                //devoloper error
                if (_env.IsDevelopment())
                {
                    _logger.LogError(ex, "An error occurred while updating a employee.");
                }
                else
                {
                    //user error
                    _logger.LogError(ex, "An error occurred while updating a employee.");
                    return View("Error", ex);
                }
            }
            return View(employeeDto);

        }

        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id) 
        {
         if(id==0) return BadRequest();
            try
            {
                bool IsDeleted = _employeeService.DeleteEmployee(id);
            
                if (IsDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can not be Deleted !!");//Error Message
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Employee can not be Deleted bacua :{ex.Message}");
                }
                else
                {
                    //user error
                    _logger.LogError($"Employee can not be Deleted bacua ::{ex}");
                    return View("ErrorView", ex);
                }
            }
            return RedirectToAction(nameof(Delete), new { id });
        }
        #endregion

    }
}
