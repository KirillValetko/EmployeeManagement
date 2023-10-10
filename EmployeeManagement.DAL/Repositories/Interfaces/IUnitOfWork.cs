namespace EmployeeManagement.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
