using Pro.BusinessLogic.DTOS.DepartmentDtos;
using Proj.DataAccess.Data.Repositories.Models.DepartmentModule;

namespace Pro.BusinessLogic.Factories
{
    public static class DepartmentFactory
   
    {
        //to convert department to departmentDto for view 
        //mapping 
        public static DepartmentDto ToDepartmentDto(this Department d)
        {
            return new DepartmentDto()
            {
                DeptId = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = d.CreatedOn.HasValue ? DateOnly.FromDateTime(d.CreatedOn.Value) : default
            };
        }
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedOn = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default,
                ModefiedBy = department.ModefiedBy,
                ModefiedOn = department.ModefiedOn.HasValue ? DateOnly.FromDateTime(department.ModefiedOn.Value) : default,
                IsDeleted = department.IsDeleted
            };
        }
        // departmentDto to department for create and update
        public static Department ToEntity(this CreateEmployeetDto dto)
        {
            return new Department()
            {
               
                Description = dto.Description,
                Code = dto.Code,
                Name = dto.Name,
                CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
        public static Department ToEntity(this UpdatedDepartmentDto dto)
        {
            return new Department()
            {
                Id = dto.Id,
                Description = dto.Description,
                Code = dto.Code,
                Name = dto.Name,
                CreatedOn = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
