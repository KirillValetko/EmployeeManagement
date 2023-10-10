using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.DAL.Repositories.Interfaces
{
    public interface ISpecialtyRepository : IBaseRepository<Specialty, SpecialtyDataModel, SpecialtyFilter>
    {
    }
}
