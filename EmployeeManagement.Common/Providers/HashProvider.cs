using System.Security.Cryptography;
using System.Text;
using EmployeeManagement.Common.Providers.Interfaces;

namespace EmployeeManagement.Common.Providers
{
    public class HashProvider : IHashProvider
    {
        public string GetHash(string password, string salt)
        {
            var sha512 = SHA512.Create();
            var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            var stringHash = Convert.ToBase64String(hash) + salt;

            return stringHash;
        }
    }
}
