using AutoMapper;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.DAL.Infrastructure.MapperValueResolvers
{
    public class UserValueResolver : IValueResolver<User, UserDataModel, string>
    {
        public string Resolve(User source, UserDataModel destination, string destMember, ResolutionContext context)
        {
            return source.Role == 0 ? RoleConstants.Employee : RoleConstants.Administrator;
        }
    }
}
