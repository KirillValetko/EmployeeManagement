using AutoMapper;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.Common.Models;
using EmployeeManagement.Web.Models.DtoModels;
using EmployeeManagement.Web.Models.ViewModels;

namespace EmployeeManagement.Web.Infrastructure
{
    public class ApiMapperProfiles : Profile
    {
        public ApiMapperProfiles()
        {
            CreateMap<UserDto, UserModel>();
            CreateMap<PaginationResponse<EmployeeModel>, PaginationResponse<EmployeeViewModel>>();
            CreateMap<EmployeeDto, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeViewModel>();
            CreateMap<PaginationResponse<SpecialtyModel>, PaginationResponse<SpecialtyViewModel>>();
            CreateMap<SpecialtyDto, SpecialtyModel>();
            CreateMap<SpecialtyModel, SpecialtyViewModel>();
        }
    }
}
