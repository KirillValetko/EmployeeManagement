using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.Common.Providers.Interfaces;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashProvider _hashProvider;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository employeeRepository,
            IHashProvider hashProvider,
            IConfiguration configuration)
        {
            _userRepository = employeeRepository;
            _hashProvider = hashProvider;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(string accountName, string password)
        {
            var user = await _userRepository.GetByFilterAsync(
                new UserFilter { AccountName = accountName });

            if (user == null)
            {
                throw new Exception(ExceptionMessageConstants.InvalidCredentials);
            }
            
            var salt = user.Password.Substring(user.Password.LastIndexOf(SaltConstants.Separator) + 1);
            var hash = _hashProvider.GetHash(password, salt);

            if (user.Password != hash)
            {
                throw new Exception(ExceptionMessageConstants.InvalidCredentials);
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.Role, user.Role),
                new (ClaimTypes.NameIdentifier, user.EmployeeId.ToString())
            };

            var jwt = new JwtSecurityToken(
                issuer: JwtOptionsConstants.IssuerOpt,
                audience: JwtOptionsConstants.AudienceOpt,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[JwtOptionsConstants.Key])),
                    SecurityAlgorithms.HmacSha256)
            );
            
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
