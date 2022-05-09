using System.Security.Cryptography;
using System.Text;

namespace LibraryBuisnessLogicLayer
{
    public static class Hasher
    {
        public static string[] HashSalt(string password)
        {
            byte[] varhashedBytes;
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[32];
            rng.GetBytes(salt);
            byte[] hashedBytes = Encoding.UTF8.GetBytes(password + Convert.ToBase64String(salt));
            SHA256Managed hashString = new SHA256Managed();
            byte[] hashed = hashString.ComputeHash(hashedBytes);
            string bytestring = Convert.ToHexString(hashed);
            return new string[2] { bytestring, Convert.ToBase64String(salt) };
        }

        public static string Hash(string password, string salt)
        {
            byte[] hashedBytes = Encoding.UTF8.GetBytes(password + salt);
            SHA256Managed hashString = new SHA256Managed();
            byte[] hashed = hashString.ComputeHash(hashedBytes);
            string bytestring = Convert.ToHexString(hashed);
            return bytestring;
        }
    }
}
