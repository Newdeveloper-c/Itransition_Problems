using DZen.Security.Cryptography;
using System.Text;

namespace Problem2;

public static class Helper
{
    public static string CalculateSHA3256Hash(string data, bool isData = false)
    {
        var hash = Array.Empty<byte>();
        using (var sha3 = SHA3.Create())
            if (isData)
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                hash = sha3.ComputeHash(dataBytes);
            }
            else
                using (var stream = new FileStream(data, FileMode.Open, FileAccess.Read))
                {
                    hash = sha3.ComputeHash(stream);
                }

        var sb = new StringBuilder();

        foreach (byte b in hash)
            sb.Append(b.ToString("X2"));

        return sb.ToString().ToLower();
    }
}
