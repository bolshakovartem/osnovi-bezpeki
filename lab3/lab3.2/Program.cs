using System;
using System.Security.Cryptography;
using System.Text;

namespace lab3._2
{
    class Program
    {
        static byte[] ComputeHashMd5(byte[] dataForHash)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(dataForHash);
            }

        }
        static void Main(string[] args)
        {
            Guid guid1 = new Guid("564c8da6-0440-88ec-d453-0bbad57c6036");
            string a = "po1MVkAE7IjUUwu61XxgNg==";
            string Hash;
            for (int i = 99999999; i >= 0; i--)
            { 
                string password = i.ToString();
                for(int q = password.Length; q <8; q++)
                {
                    password = "0" + password;
                }
                Hash = Convert.ToBase64String(ComputeHashMd5(Encoding.Unicode.GetBytes(password)));
                if(Hash == a)
                {
                    Console.WriteLine(Hash);
                    Console.WriteLine(password);
                    break;
                }
                Console.WriteLine(password);
            }
                
        }
    }
}
