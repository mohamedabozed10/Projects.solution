
namespace Proj.DataAccess.Modules
{
    public  class BaseEntity //include the common props (parent)
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } //user id who created the record
        public DateTime? CreatedOn { get; set; }  //the date time of create record
        public int  ModefiedBy { get; set; } //user id who modified the record
        public DateTime? ModefiedOn { get; set; } //the date time of modify record
        public bool IsDeleted { get; set; } //for soft delete

    }
}
