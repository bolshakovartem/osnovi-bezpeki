using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TripleDes
{
    class Program
    {
        public byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public byte[] Encrypt(byte[] dataToEncrypt,
                              byte[] key,
                              byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(
                    memoryStream,
                    des.CreateEncryptor(),
                    CryptoStreamMode.Write);
                    cryptoStream.Write(dataToEncrypt, 0,
                    dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream =
                        new CryptoStream(memoryStream,
                        des.CreateDecryptor(),
                        CryptoStreamMode.Write);
                    cryptoStream.Write(dataToDecrypt, 0,
                    dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();
                    var decryptBytes = memoryStream.ToArray();
                    return decryptBytes;
                }
            }
        }
        static void Main(string[] args)
        {
            var tripledes = new Program();
            var key = tripledes.GenerateRandomNumber(24);
            var iv = tripledes.GenerateRandomNumber(8);
            const string original = "Text to encrypt";
            var encrypted = tripledes.Encrypt(
            Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = tripledes.Decrypt(encrypted, key, iv);
            var decryptedMessage = Encoding.UTF8.GetString(decrypted);
            Console.WriteLine("TripleDES Encryption in .NET");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " +
            Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + decryptedMessage);
            Console.ReadLine();

        }
    }
}
