namespace EmployeeManagement.DAL.Filters
{
    public class BaseFilter
    {
        public Guid? Id { get; set; }
        public List<Guid> Ids { get; set; }
    }
}
