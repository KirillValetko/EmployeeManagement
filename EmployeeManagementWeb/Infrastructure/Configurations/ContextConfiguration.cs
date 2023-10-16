using Microsoft.EntityFrameworkCore;
using EmployeeManagement.DAL.Infrastructure;

namespace EmployeeManagement.Web.Infrastructure.Configurations
{
    public static class ContextConfiguration
    {
        private const string ConnectionString = "ConnectionStrings:EmployeeDB";

        public static void InitDbContext(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                var str = configuration.GetSection(environment.EnvironmentName)[ConnectionString];
                services.AddDbContext<EmployeeManagementContext>(opt =>
                    opt.UseSqlServer(configuration[ConnectionString]));
            }
            else
            {
                var str = configuration.GetSection(environment.EnvironmentName)[ConnectionString];
                services.AddDbContext<EmployeeManagementContext>(opt =>
                    opt.UseNpgsql(configuration[ConnectionString]));
            }
        }
    }
}
