using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordHashing
{
    public static class Authenticator
    {
        public static string GenerateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GenerateHash(string input, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(input + salt);
            var sHA256ManagedString = new SHA256Managed();
            var hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool Authenticate(string password, string hashedInput, string salt)
        {
            var newHash = GenerateHash(password, salt);
            return newHash.Equals(hashedInput);
        }
    }
}
