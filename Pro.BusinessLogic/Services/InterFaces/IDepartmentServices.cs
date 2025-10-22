using Pro.BusinessLogic.DTOS.DepartmentDtos;

namespace Pro.BusinessLogic.Services.InterFaces
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreateEmployeetDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}