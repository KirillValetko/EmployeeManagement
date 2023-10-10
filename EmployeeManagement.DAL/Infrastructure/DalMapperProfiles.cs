using AutoMapper;
using EmployeeManagement.Common.Models;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Infrastructure.MapperValueResolvers;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.DAL.Infrastructure
{
    public class DalMapperProfiles : Profile
    {
        public DalMapperProfiles()
        {
            CreateMap<PaginationResponse<User>, PaginationResponse<UserDataModel>>();
            CreateMap<User, UserDataModel>()
                .ForMember(dest => dest.Role, 
                opt => opt.MapFrom<UserValueResolver>());
            CreateMap<UserDataModel, User>()
                .ForMember(dest => dest.Role, 
                    opt => opt.Ignore());
            CreateMap<PaginationResponse<Employee>, PaginationResponse<EmployeeDataModel>>();
            CreateMap<Employee, EmployeeDataModel>().ReverseMap();
            CreateMap<PaginationResponse<Specialty>, PaginationResponse<SpecialtyDataModel>>();
            CreateMap<Specialty, SpecialtyDataModel>().ReverseMap();
        }
    }
}
