namespace EmployeeManagement.DAL.Models
{
    public class Specialty : BaseDbModel
    {
        public string SpecialtyName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
