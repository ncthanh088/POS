namespace POS.MultiApp.Helpers;
using System.Security.Cryptography;

public static class Cryptography
{
    public static string GenerateHash(string value)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashBytes = sha256.ComputeHash(System.Text.Encoding.ASCII.GetBytes(value));
            return Convert.ToBase64String(hashBytes);
        }
    }

    public static string DecodeHash(string hash)
    {
        var hashBytes = Convert.FromBase64String(hash);
        using (var sha256 = SHA256.Create())
        {
            var originalBytes = sha256.ComputeHash(hashBytes);
            return System.Text.Encoding.ASCII.GetString(originalBytes);
        }
    }
}
