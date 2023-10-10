using AutoMapper;
using EmployeeManagement.Common.Helpers.Interfaces;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Infrastructure;
using EmployeeManagement.DAL.Models;
using EmployeeManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories
{
    public class EmployeeRepository : 
        BaseRepository<Employee, EmployeeDataModel, EmployeeFilter>,
        IEmployeeRepository
    {
        public EmployeeRepository(EmployeeManagementContext employeeManagementContext,
            IPaginationHelper<Employee> paginationHelper,
            IMapper mapper)
        : base(employeeManagementContext, paginationHelper, mapper)
        {
        }

        protected override IQueryable<Employee> AddFilterConditions(IQueryable<Employee> items, EmployeeFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.FullName))
            {
                items = items.Where(employee => employee.FullName.Contains(filter.FullName));
            }

            if (filter.SpecialtyId.HasValue)
            {
                items = items.Where(employee => employee.SpecialtyId.Equals(filter.SpecialtyId.Value));
            }

            items = items.Include(e => e.Specialty);

            return items;
        }
    }
}
