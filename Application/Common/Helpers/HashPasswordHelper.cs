using System.Security.Cryptography;
using System.Text;

namespace Application.Common.Helpers;
public static class HashPasswordHelper
{
    public static string HashPassword(string password)
    {
        Byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        Byte[] hashedBytes = SHA256.Create().ComputeHash(passwordBytes);

        var hashedPassword = BitConverter.ToString(hashedBytes);

        return hashedPassword.Replace("-", "");
    }
}
