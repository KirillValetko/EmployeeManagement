namespace EmployeeManagement.DAL.Models
{
    public class User : BaseDbModel
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
