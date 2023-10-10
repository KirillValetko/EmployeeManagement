using AutoMapper;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.Web.Models.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService,
            IMapper mapper, 
            ILogger<AuthenticationController> logger) : base(mapper, logger)
        {
            _authenticationService = authenticationService;
        }
        
        [HttpPost]
        public Task<IActionResult> PostAsync(LoginDto item)
        {
            return ProcessRequest(() => 
                _authenticationService.AuthenticateAsync(item.AccountName, item.Password));
        } 
    }
}
