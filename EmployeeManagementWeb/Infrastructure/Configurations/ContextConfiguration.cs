using Microsoft.EntityFrameworkCore;
using EmployeeManagement.DAL.Infrastructure;

namespace EmployeeManagement.Web.Infrastructure.Configurations
{
    public static class ContextConfiguration
    {
        private const string ConnectionString = "ConnectionStrings:EmployeeDB";

        public static void InitDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeManagementContext>(opt =>
                opt.UseSqlServer(configuration[ConnectionString]));
        }
    }
}
