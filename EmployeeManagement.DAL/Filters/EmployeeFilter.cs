namespace EmployeeManagement.DAL.Filters
{
    public class EmployeeFilter : BaseFilter
    {
        public string FullName { get; set; }
        public Guid? SpecialtyId { get; set; } 
    }
}
