using System;

namespace PasswordHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Password:");
            var password = Console.ReadLine();

            //1. Generate Salt & Hash. Store it in database instead of storing password.
            var salt = Authenticator.GenerateSalt(40);
            var hash = Authenticator.GenerateHash(password, salt);
            Console.WriteLine($"Hash: {hash}");
            Console.WriteLine($"Salt: {salt}");

            //2. Retrive Salt & Hash from database. Generate hash with the same salt for the input password.
            //3. The hash stored and new hash should match when the password is same.
            var newHash = Authenticator.GenerateHash(password, salt);
            var isAuthenticated = newHash.Equals(hash);

            Console.WriteLine($"New Hash: {hash}");
            Console.WriteLine(isAuthenticated);
            Console.ReadKey();
        }
    }
}
