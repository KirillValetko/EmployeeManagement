using AutoMapper;
using EmployeeManagement.Common.Helpers.Interfaces;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Infrastructure;
using EmployeeManagement.DAL.Models;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.DAL.Repositories
{
    public class UserRepository :
        BaseRepository<User, UserDataModel, UserFilter>,
        IUserRepository
    {
        public UserRepository(EmployeeManagementContext employeeManagementContext,
            IPaginationHelper<User> paginationHelper,
            IMapper mapper) : base(employeeManagementContext, paginationHelper, mapper)
        {
        }

        protected override void PrepareForCreation(User item)
        {
            base.PrepareForCreation(item);
            item.Role = 0;
        }


        protected override void SaveImportantInfo(User beforeSave, UserDataModel forSave)
        {
            base.SaveImportantInfo(beforeSave, forSave);
            forSave.AccountName = beforeSave.AccountName;
            forSave.EmployeeId = beforeSave.EmployeeId;
        }

        protected override IQueryable<User> AddFilterConditions(IQueryable<User> items, UserFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.AccountName))
            {
                items = items.Where(user => user.AccountName.Equals(filter.AccountName));
            }

            return items;
        }
    }
}
