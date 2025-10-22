using AutoMapper;
using Pro.BusinessLogic.DTOS.EmployeeDtos;
using Proj.DataAccess.Data.Repositories.Interfaces;
using Proj.DataAccess.Data.Repositories.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.BusinessLogic.Services.Classes
{
    public class EmployeeServices(IEmployeeRepository _employeeRepository,IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll(withTracking);
            //Mapping Using AutoMapper==>src=>ienumrable<Employee> ,dest=>ienumerable<EmployeeDto>
            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            //var employeesDto=employees.Select(e => new EmployeeDto()
            //{
            //    Age = e.Age,
            //    Id = e.Id,
            //    Name = e.Name,
            //    IsActive = e.IsActive,
            //    Email = e.Email,
            //    Salary = e.Salary,
            //    Gender=e.Gender.ToString(),
            //    EmployeeType = e.EmployeeType.ToString()
            //});
            return employeesDto;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return null;
            else
            {
                return _mapper.Map<Employee, EmployeeDetailsDto>(employee);
                //{
                //    Email = employee.Email,
                //    Address = employee.Address,
                //    Age = employee.Age,
                //    Name = employee.Name, 
                //    PhoneNumber = employee.PhoneNumber,
                //    IsActive = employee.IsActive,
                //    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                //    Id = employee.Id,
                //    Salary = employee.Salary,
                //    Gender=employee.Gender.ToString(),
                //    EmployeeType = employee.EmployeeType.ToString(),
                //    CreatedOn = employee.CreatedOn,
                //    ModifiedBy =1,
                //    CreatedBy = 1,
                //    ModifiedOn = employee.ModifiedOn,

                //};
            }
        }

        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee=_mapper.Map<CreateEmployeeDto, Employee>(employeeDto);
            return _employeeRepository.Add(employee);
        }

      
       
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
           //in the same line 
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }
        public bool DeleteEmployee(int id) 
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else
            {
                 employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0 ?true :false;
            }

        }
    }
}
