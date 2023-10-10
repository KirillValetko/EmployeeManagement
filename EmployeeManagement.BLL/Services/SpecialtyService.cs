using AutoMapper;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Models;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.BLL.Services
{
    public class SpecialtyService :
        BaseService<Specialty, SpecialtyDataModel, SpecialtyModel, SpecialtyFilter>,
        ISpecialtyService
    {
        public SpecialtyService(ISpecialtyRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
