using EmployeeManagement.BLL.Models;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.BLL.Services.Interfaces
{
    public interface IUserService : IBaseService<User, UserDataModel, UserModel, UserFilter>
    {
    }
}
