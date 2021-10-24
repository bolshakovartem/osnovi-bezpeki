using System;
using System.Security.Cryptography;
using System.Text;

namespace lab3._3
{
    public class HMAC
    {
        private const int SIZE = 32;

        public static byte[] GenerateKey()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[SIZE];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static byte[] ComputeHMACSHA1(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA1(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
        public static byte[] ComputeHMACSHA256(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
        public static byte[] ComputeHMACSHA512(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA512(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
        public static byte[] ComputeHMACMD5(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACMD5(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var str = "Hello world!";
            var str1 = "qwertyasdfgxcvb";

            var key = HMAC.GenerateKey();

            var hmacmd5str = HMAC.ComputeHMACMD5(Encoding.UTF8.GetBytes(str),key);
            var hmacmd5str1 = HMAC.ComputeHMACMD5(Encoding.UTF8.GetBytes(str1), key);

            var hmacsha1str = HMAC.ComputeHMACSHA1(Encoding.UTF8.GetBytes(str), key);
            var hmacsha1str1 = HMAC.ComputeHMACSHA1(Encoding.UTF8.GetBytes(str1), key);

            var hmacsha256str = HMAC.ComputeHMACSHA256(Encoding.UTF8.GetBytes(str), key);
            var hmacsha256str1 = HMAC.ComputeHMACSHA256(Encoding.UTF8.GetBytes(str1), key);

            var hmacsha512str = HMAC.ComputeHMACSHA512(Encoding.UTF8.GetBytes(str), key);
            var hmacsha512str1 = HMAC.ComputeHMACSHA512(Encoding.UTF8.GetBytes(str1), key);

            Console.WriteLine("MD5 HMAC");
            Console.WriteLine();

            Console.WriteLine("String hash: " + Convert.ToBase64String(hmacmd5str));
            Console.WriteLine("String1 hash: " + Convert.ToBase64String(hmacmd5str1));

            Console.WriteLine();
            Console.WriteLine("SHA1 HMAC");
            Console.WriteLine();

            Console.WriteLine("String hash: " + Convert.ToBase64String(hmacsha1str));
            Console.WriteLine("String1 hash: " + Convert.ToBase64String(hmacsha1str1));

            Console.WriteLine();
            Console.WriteLine("SHA256 HMAC");
            Console.WriteLine();

            Console.WriteLine("String hash: " + Convert.ToBase64String(hmacsha256str));
            Console.WriteLine("String1 hash: " + Convert.ToBase64String(hmacsha256str1));

            Console.WriteLine();
            Console.WriteLine("SHA512 HMAC");
            Console.WriteLine();

            Console.WriteLine("String hash: " + Convert.ToBase64String(hmacsha512str));
            Console.WriteLine("String1 hash: " + Convert.ToBase64String(hmacsha512str1));

            Console.WriteLine();
            Console.ReadLine();
        }

       
    }
}
