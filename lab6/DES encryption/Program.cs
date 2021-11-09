using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DES_encryption
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
            using (var des = new DESCryptoServiceProvider())
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
            using (var des = new DESCryptoServiceProvider())
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
            var des = new Program();
            var key = des.GenerateRandomNumber(8);
            var iv = des.GenerateRandomNumber(8);
            const string original = "Text to encrypt";
            var encrypted = des.Encrypt(
            Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = des.Decrypt(encrypted, key, iv);
            var decryptedMessage = Encoding.UTF8.GetString(decrypted);
            Console.WriteLine("DES Encryption in .NET");
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
