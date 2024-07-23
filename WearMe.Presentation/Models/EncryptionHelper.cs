using System.Security.Cryptography;

namespace WearMe.Presentation.Models
{
    public class EncryptionHelper
    {
        private static readonly string EncryptionKey = "j5Vy7i4mULYCOhEZaY0n1gXUb873ULUVIVRqaXYwYhw="; // Use a secure key and store it securely

        public static byte[] EncryptBytes(byte[] plainBytes)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(EncryptionKey);
                aes.GenerateIV();
                var iv = aes.IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, iv))
                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(iv, 0, iv.Length); // Prepend IV to the encrypted data
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    return memoryStream.ToArray();
                }
            }
        }

        public static byte[] DecryptBytes(byte[] cipherBytes)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(EncryptionKey);

                using (var memoryStream = new MemoryStream(cipherBytes))
                {
                    var iv = new byte[16];
                    memoryStream.Read(iv, 0, iv.Length); // Read IV from the encrypted data
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    using (var resultStream = new MemoryStream())
                    {
                        cryptoStream.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }
                }
            }
        }
    }
}
