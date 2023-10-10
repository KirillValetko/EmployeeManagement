namespace EmployeeManagement.BLL.Models
{
    public class UserModel : BaseModel
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Guid EmployeeId { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}
