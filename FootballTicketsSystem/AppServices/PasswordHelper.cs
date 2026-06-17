using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FootballTicketsSystem.AppServices
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16;   // 128 bit
        private const int KeySize = 32;    // 256 bit
        private const int Iterations = 10000;

        // Создание хэша
        public static (string hash, string salt) CreatePassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[SaltSize];
                rng.GetBytes(saltBytes);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
                {
                    byte[] hashBytes = pbkdf2.GetBytes(KeySize);

                    return (
                        Convert.ToBase64String(hashBytes),
                        Convert.ToBase64String(saltBytes)
                    );
                }
            }
        }

        // Проверка пароля
        public static bool VerifyPassword(string password, string hash, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
            {
                byte[] hashBytes = pbkdf2.GetBytes(KeySize);
                string newHash = Convert.ToBase64String(hashBytes);

                return newHash == hash;
            }
        }
    }
}
