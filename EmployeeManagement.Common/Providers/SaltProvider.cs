﻿using System.Security.Cryptography;
using System.Text;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.Common.Providers.Interfaces;

namespace EmployeeManagement.Common.Providers
{
    public class SaltProvider : ISaltProvider
    {
        public string GetSalt()
        {
            var saltSize = RandomNumberGenerator.GetInt32(12, 21);
            var salt = new StringBuilder();

            for (var i = 0; i < saltSize; i++)
            {
                salt.Append(SaltConstants.Characters[RandomNumberGenerator.GetInt32(SaltConstants.Characters.Length)]);
            }

            return salt.ToString();
        }
    }
}
