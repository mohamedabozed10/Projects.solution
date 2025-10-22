

using Pro.BusinessLogic.DTOS.EmployeeDtos;

namespace Proj.DataAccess.Data.Repositories.Interfaces
{
    public interface IEmployeeService
    {
        //GetAll
        IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking=false);
        //GetById
        EmployeeDetailsDto? GetEmployeeById(int id);
        //Create employee
        int CreateEmployee(CreateEmployeeDto employeeDto);
        //Update employee 
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);

    }
}
