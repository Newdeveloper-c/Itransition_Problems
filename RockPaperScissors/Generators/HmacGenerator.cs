using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors.Generators;

public static class HmacGenerator
{
    public static string GenerateSHA2Hmac(string key, string data)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);

        using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
        {
            var hmacValue = hmac.ComputeHash(dataBytes);

            return BitConverter.ToString(hmacValue).Replace("-", "");
        } 
    }
}
