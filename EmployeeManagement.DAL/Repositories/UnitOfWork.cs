using EmployeeManagement.DAL.Infrastructure;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementContext _employeeManagementContext;

        public UnitOfWork(EmployeeManagementContext employeeManagementContext)
        {
            _employeeManagementContext = employeeManagementContext;
        }

        public async Task SaveAsync()
        {
            await _employeeManagementContext.SaveChangesAsync();
        }
    }
}
