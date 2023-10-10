namespace EmployeeManagement.DAL.DataModels
{
    public class UserDataModel : BaseDataModel
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Guid EmployeeId { get; set; }

        public EmployeeDataModel Employee { get; set; }
    }
}
