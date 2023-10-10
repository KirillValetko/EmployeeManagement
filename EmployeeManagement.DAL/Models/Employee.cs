namespace EmployeeManagement.DAL.Models
{
    public class Employee : BaseDbModel
    {
        public string FullName { get; set; }
        public Guid SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }
        public User User { get; set; }
    }
}
