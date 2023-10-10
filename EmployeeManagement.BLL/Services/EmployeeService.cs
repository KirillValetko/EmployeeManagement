using AutoMapper;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Models;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.BLL.Services
{
    public class EmployeeService :
        BaseService<Employee, EmployeeDataModel, EmployeeModel, EmployeeFilter>,
        IEmployeeService

    {
        private readonly ISpecialtyRepository _specialtyRepository;

        public EmployeeService(IEmployeeRepository repository,
            ISpecialtyRepository specialtyRepository,
            IUnitOfWork unitOfWork, 
            IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _specialtyRepository = specialtyRepository;
        }

        public override async Task UpdateAsync(EmployeeModel item)
        {
            var dbItem = await _repository.GetByFilterAsync(
                new EmployeeFilter { Id = item.Id });

            if (dbItem == null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            var mappedItem = _mapper.Map<EmployeeDataModel>(item);

            if (item.SpecialtyId != dbItem.SpecialtyId)
            {
                var specialty = await _specialtyRepository.GetByFilterAsync(
                    new SpecialtyFilter { Id = item.SpecialtyId });

                if (specialty == null)
                {
                    throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
                }
            }

            await _repository.UpdateAsync(mappedItem);
            await _unitOfWork.SaveAsync();
        }
    }
}
