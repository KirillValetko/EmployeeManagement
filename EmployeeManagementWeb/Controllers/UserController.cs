using AutoMapper;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.Web.Infrastructure.Attributes;
using EmployeeManagement.Web.Models.DtoModels;
using EmployeeManagement.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Authorize]
    [RequiresRoleClaim(RoleConstants.Administrator)]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService,
            IMapper mapper,
            ILogger<BaseController> logger) : base(mapper, logger)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public Task<IActionResult> PostAsync(UserDto item)
        {
            var mappedItem = _mapper.Map<UserModel>(item);

            return ProcessRequest<UserModel>(() => _userService.CreateAsync(mappedItem));
        }
    }
}
