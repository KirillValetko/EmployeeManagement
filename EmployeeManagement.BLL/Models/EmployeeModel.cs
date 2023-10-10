namespace EmployeeManagement.BLL.Models
{
    public class EmployeeModel : BaseModel
    {
        public string FullName { get; set; }
        public Guid SpecialtyId { get; set; }

        public SpecialtyModel Specialty { get; set; }
    }
}
