using EmployeeManagement.BLL.Infrastructure;
using EmployeeManagement.DAL.Infrastructure;

namespace EmployeeManagement.Web.Infrastructure.Configurations
{
    public static class MapperConfiguration
    {
        public static void InitMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DalMapperProfiles), typeof(BllMapperProfiles), typeof(ApiMapperProfiles));
        }
    }
}
