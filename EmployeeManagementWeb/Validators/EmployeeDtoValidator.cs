using EmployeeManagement.Web.Models.DtoModels;
using FluentValidation;

namespace EmployeeManagement.Web.Validators
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(e => e.FullName).NotEmpty();
            RuleFor(e => e.SpecialtyId).NotEmpty();
        }
    }
}
