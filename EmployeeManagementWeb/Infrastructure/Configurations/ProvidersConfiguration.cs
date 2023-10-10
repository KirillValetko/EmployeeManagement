using EmployeeManagement.Common.Providers;
using EmployeeManagement.Common.Providers.Interfaces;

namespace EmployeeManagement.Web.Infrastructure.Configurations
{
    public static class ProvidersConfiguration
    {
        public static void InitProviders(this IServiceCollection services)
        {
            services.AddScoped<IHashProvider, HashProvider>();
            services.AddScoped<ISaltProvider, SaltProvider>();
        }
    }
}
