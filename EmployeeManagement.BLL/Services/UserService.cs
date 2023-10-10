using AutoMapper;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.Common.Providers.Interfaces;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Models;
using EmployeeManagement.DAL.Repositories.Interfaces;

namespace EmployeeManagement.BLL.Services
{
    public class UserService :
        BaseService<User, UserDataModel, UserModel, UserFilter>,
        IUserService
    {
        private readonly IHashProvider _hashProvider;
        private readonly ISaltProvider _saltProvider;

        public UserService(IUserRepository repository,
            IHashProvider hashProvider,
            ISaltProvider saltProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _hashProvider = hashProvider;
            _saltProvider = saltProvider;
        }

        public override async Task CreateAsync(UserModel item)
        {
            var mappedItem = _mapper.Map<UserDataModel>(item);
            var salt = _saltProvider.GetSalt();
            var hash = _hashProvider.GetHash(mappedItem.Password, salt);
            mappedItem.Password = hash;
            _repository.Create(mappedItem);
            await _unitOfWork.SaveAsync();
        }
    }
}
