using EmployeeManagement.DAL.Repositories;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.Web.Infrastructure.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static void InitRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
