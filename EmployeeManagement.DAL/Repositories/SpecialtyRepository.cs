using AutoMapper;
using EmployeeManagement.Common.Helpers.Interfaces;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Infrastructure;
using EmployeeManagement.DAL.Models;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.DAL.Repositories
{
    public class SpecialtyRepository : 
        BaseRepository<Specialty, SpecialtyDataModel, SpecialtyFilter>,
        ISpecialtyRepository 
    {
        public SpecialtyRepository(EmployeeManagementContext employeeManagementContext,
            IPaginationHelper<Specialty> paginationHelper,
            IMapper mapper) : base(employeeManagementContext, paginationHelper, mapper)
        {
        }

        protected override IQueryable<Specialty> AddFilterConditions(IQueryable<Specialty> items, SpecialtyFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.SpecialtyName))
            {
                items = items.Where(specialty => specialty.SpecialtyName.Contains(filter.SpecialtyName));
            }

            return items;
        }
    }
}
