using Pro.BusinessLogic.DTOS.DepartmentDtos;
using Pro.BusinessLogic.Factories;
using Pro.BusinessLogic.Services.InterFaces;
using Proj.DataAccess.Data.Repositories.Classes;
using Proj.DataAccess.Data.Repositories.Interfaces;

namespace Pro.BusinessLogic.Services.Classes
{
    //الخلاصه 
    //service get data from repository
    //factory convert data from entity to dto and do any business logic
    //service return dto to controller 
    public class DepartmentServices(IDepartmentRepository _departmentRepository) : IDepartmentServices
    {

        //[GetAll]
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return departments.Select(d => d.ToDepartmentDto());

        }
        //[GetById]
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            //if (department == null) return null;
            //return department.ToDepartmentDetailsDto(); 
            return department is null ? null : department.ToDepartmentDetailsDto();//on one line 
        }
        //[Add]
        public int AddDepartment(CreateEmployeetDto departmentDto)
        {
            return _departmentRepository.Add(departmentDto.ToEntity());
        }
        //[Update]
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());
        }
        //[Delete]
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) return false;
            int NumberOfRowsAffected = _departmentRepository.Remove(department);
            return NumberOfRowsAffected > 0 ? true : false;
        }
    }
}
