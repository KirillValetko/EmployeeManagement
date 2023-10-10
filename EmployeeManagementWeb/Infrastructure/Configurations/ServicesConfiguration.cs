using EmployeeManagement.BLL.Services;
using EmployeeManagement.BLL.Services.Interfaces;

namespace EmployeeManagement.Web.Infrastructure.Configurations
{
    public static class ServicesConfiguration
    {
        public static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ISpecialtyService, SpecialtyService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
