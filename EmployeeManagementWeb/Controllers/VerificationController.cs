using AutoMapper;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.Web.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VerificationController : BaseController
    {
        public VerificationController(IMapper mapper,
            ILogger<BaseController> logger) : base(mapper, logger)
        {
        }

        [HttpGet]
        public IActionResult GetAsync()
        {
            var token = string.Empty;

            if (Request.Headers.TryGetValue(VerificationConstants.Authorization, out var headers))
            {
                token = headers.FirstOrDefault();
            }

            return Ok(new ApiResponse<string>{Payload = token});
        }
    }
}
