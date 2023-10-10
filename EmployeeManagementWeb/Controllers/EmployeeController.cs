using System.Security.Claims;
using AutoMapper;
using EmployeeManagement.BLL.Models;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.Common.Models;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.Web.Infrastructure.Attributes;
using EmployeeManagement.Web.Models.DtoModels;
using EmployeeManagement.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Authorize]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService,
            IMapper mapper,
            ILogger<EmployeeController> logger) : base(mapper, logger)
        {
            _employeeService = employeeService;
        }

        [HttpGet("Profile")]
        public Task<IActionResult> GetAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var id = Guid.Empty;

            if (identity != null)
            {
                var claims = identity.Claims;
                id = Guid.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            }

            return ProcessRequest<EmployeeModel, EmployeeViewModel>(() =>
                _employeeService.GetByFilterAsync(new EmployeeFilter { Id = id }));
        }

        [HttpGet]
        public Task<IActionResult> GetAsync([FromQuery] PaginationRequest<EmployeeFilter> request)
        {
            return ProcessRequest<PaginationResponse<EmployeeModel>, PaginationResponse<EmployeeViewModel>>(() =>
                _employeeService.GetPaginatedAsync(request));
        }

        [RequiresRoleClaim(RoleConstants.Administrator)]
        [HttpPut]
        public Task<IActionResult> PutAsync(EmployeeDto item)
        {
            var mappedItem = _mapper.Map<EmployeeModel>(item);

            return ProcessRequest<EmployeeViewModel>(() =>
                _employeeService.UpdateAsync(mappedItem));
        }

        [RequiresRoleClaim(RoleConstants.Administrator)]
        [HttpDelete]
        public Task<IActionResult> DeleteAsync(Guid id)
        {
            return ProcessRequest<EmployeeViewModel>(() =>
                _employeeService.DeleteAsync(id));
        }
    }
}
