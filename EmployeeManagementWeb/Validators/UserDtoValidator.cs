using EmployeeManagement.Web.Models.DtoModels;
using FluentValidation;

namespace EmployeeManagement.Web.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.AccountName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
