using System.Security.Cryptography;

namespace RockPaperScissors.Generators;

public static class KeyGenarator
{
    public static string GenerateKey()
    {
        int keyLengthInBits = 256;
        int keyLengthInBytes = keyLengthInBits / 8;

        var keyBytes = new byte[keyLengthInBytes];

        using (var rngCsp = new RNGCryptoServiceProvider())
        {
            rngCsp.GetBytes(keyBytes);
        }

        return BitConverter.ToString(keyBytes).Replace("-", "");
    }
}
