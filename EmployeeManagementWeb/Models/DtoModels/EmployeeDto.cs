namespace EmployeeManagement.Web.Models.DtoModels
{
    public class EmployeeDto : BaseDto
    {
        public string FullName { get; set; }
        public Guid SpecialtyId { get; set; }
    }
}
