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
    public class SpecialtyController : BaseController
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService,
            IMapper mapper,
            ILogger<SpecialtyController> logger) : base(mapper, logger)
        {
            _specialtyService = specialtyService;
        }

        [HttpGet]
        public Task<IActionResult> GetAsync([FromQuery] PaginationRequest<SpecialtyFilter> request)
        {
            return ProcessRequest<PaginationResponse<SpecialtyModel>, PaginationResponse<SpecialtyViewModel>>(() =>
                _specialtyService.GetPaginatedAsync(request));
        }

        [RequiresRoleClaim(RoleConstants.Administrator)]
        [HttpPost]
        public Task<IActionResult> PostAsync(SpecialtyDto item)
        {
            var mappedItem = _mapper.Map<SpecialtyModel>(item);

            return ProcessRequest<SpecialtyViewModel>(() => 
                _specialtyService.CreateAsync(mappedItem));
        }

        [RequiresRoleClaim(RoleConstants.Administrator)]
        [HttpPut]
        public Task<IActionResult> PutAsync(SpecialtyDto item)
        {
            var mappedItem = _mapper.Map<SpecialtyModel>(item);

            return ProcessRequest<SpecialtyViewModel>(() =>
                _specialtyService.UpdateAsync(mappedItem));
        }

        [RequiresRoleClaim(RoleConstants.Administrator)]
        [HttpDelete]
        public Task<IActionResult> DeleteAsync(Guid id)
        {
            return ProcessRequest<SpecialtyViewModel>(() =>
                _specialtyService.DeleteAsync(id));
        }
    }
}
