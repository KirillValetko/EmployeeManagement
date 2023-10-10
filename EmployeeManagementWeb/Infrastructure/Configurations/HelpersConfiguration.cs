using EmployeeManagement.Common.Helpers;
using EmployeeManagement.Common.Helpers.Interfaces;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.Web.Infrastructure.Configurations
{
    public static class HelpersConfiguration
    {
        public static void InitHelpers(this IServiceCollection services)
        {
            services.AddScoped<IPaginationHelper<Employee>, PaginationHelper<Employee>>();
            services.AddScoped<IPaginationHelper<Specialty>, PaginationHelper<Specialty>>();
            services.AddScoped<IPaginationHelper<User>, PaginationHelper<User>>();
        }
    }
}
