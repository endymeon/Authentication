using System;
using System.Security.Cryptography;
using System.Text;

namespace TWG.Authentication.Core.Helper
{
    public static class HashHelper
    {
        private const string PwdHashKey = "yNeIfchDJ1"; 
        public static string GetPasswordHash(string username, string password, string salt)
        {
            try
            {
                //required NameSpace: using System.Text;
                //Plain Text in Byte
                var plainTextBytes = Encoding.UTF8.GetBytes(PwdHashKey + password + salt + username);

                HashAlgorithm hash = new SHA512Managed();
                var hashBytes = hash.ComputeHash(plainTextBytes);
                var saltByte = Encoding.UTF8.GetBytes(salt);
                var hashWithSaltBytes = new byte[hashBytes.Length + saltByte.Length];

                for (var i = 0; i < hashBytes.Length; i++)
                {
                    hashWithSaltBytes[i] = hashBytes[i];
                }

                for (var i = 0; i < salt.Length; i++)
                {
                    hashWithSaltBytes[hashBytes.Length + i] = saltByte[i];
                }

                return Convert.ToBase64String(hashWithSaltBytes);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}