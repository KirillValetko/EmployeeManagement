namespace EmployeeManagement.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(string accountName, string password);
    }
}
