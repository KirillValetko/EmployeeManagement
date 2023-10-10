namespace EmployeeManagement.Web.Models.DtoModels;

public class UserDto : BaseDto
{
    public string AccountName { get; set; }
    public string Password { get; set; }

    public EmployeeDto Employee { get; set; }
}