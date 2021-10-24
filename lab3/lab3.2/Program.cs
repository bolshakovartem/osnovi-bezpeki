using System;
using System.Security.Cryptography;

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
            string a = 12345678.ToString();
            for(int i=100000000;i<200000000;i++)
            {

            }
        }
    }
}
