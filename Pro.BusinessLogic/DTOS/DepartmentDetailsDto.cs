

using Proj.DataAccess.Modules;

namespace Pro.BusinessLogic.DTOS
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } //user id who created the record
        public DateOnly? CreatedOn { get; set; }  //the date time of create record
        public int ModefiedBy { get; set; } //user id who modified the record
        public DateOnly? ModefiedOn { get; set; } //the date time of modify record
        public bool IsDeleted { get; set; } //for soft delete
        public string Name { get; set; } = string.Empty;//mandatory
        public string Code { get; set; } =string.Empty; //mandatory
        public string? Description { get; set; }
        //Constractor Mapping
        //public DepartmentDetailsDto(Department department)
        //{
        //    department.Id = Id;
        //    department.CreatedBy = CreatedBy;
        //       // .....etc
        //}

    }
}
