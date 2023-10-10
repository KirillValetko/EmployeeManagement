namespace EmployeeManagement.DAL.DataModels
{
    public class EmployeeDataModel : BaseDataModel
    {
        public string FullName { get; set; }
        public Guid SpecialtyId { get; set; }

        public SpecialtyDataModel Specialty { get; set; }
    }
}
