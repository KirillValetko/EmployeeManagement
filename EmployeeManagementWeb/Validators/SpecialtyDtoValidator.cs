using EmployeeManagement.Web.Models.DtoModels;
using FluentValidation;

namespace EmployeeManagement.Web.Validators
{
    public class SpecialtyDtoValidator : AbstractValidator<SpecialtyDto>
    {
        public SpecialtyDtoValidator()
        {
            RuleFor(s => s.SpecialtyName).NotEmpty();
        }
    }
}
