using AutoMapper;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.Common.Models;
using EmployeeManagement.DAL.DataModels;

namespace EmployeeManagement.BLL.Infrastructure
{
    public class BllMapperProfiles : Profile
    {
        public BllMapperProfiles()
        {
            CreateMap<PaginationResponse<UserDataModel>, PaginationResponse<UserModel>>();
            CreateMap<UserDataModel, UserModel>().ReverseMap();
            CreateMap<PaginationResponse<EmployeeDataModel>, PaginationResponse<EmployeeModel>>();
            CreateMap<EmployeeDataModel, EmployeeModel>().ReverseMap();
            CreateMap<PaginationResponse<SpecialtyDataModel>, PaginationResponse<SpecialtyModel>>();
            CreateMap<SpecialtyDataModel, SpecialtyModel>().ReverseMap();
        }
    }
}
