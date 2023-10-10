namespace EmployeeManagement.Web.Models.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public string FullName { get; set; }

        public SpecialtyViewModel Specialty { get; set; }
    }
}
