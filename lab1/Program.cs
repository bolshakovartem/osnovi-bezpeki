using System;
using System.Security.Cryptography;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random1 = new Random(6);
            Random random2 = new Random(6);

            for(int i=0; i<10; i++)
            {
                Console.WriteLine(random1.Next(0, 20));
            }
            Console.WriteLine("");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(random2.Next(0, 20));
            }
            Console.WriteLine("");

            var randomGen = new RNGCryptoServiceProvider();
            var randomNumber = new byte[20];

            for (int i = 0; i < 10; i++)
            {
                randomGen.GetBytes(randomNumber);
                String result = Convert.ToBase64String(randomNumber); 
                Console.WriteLine(result);
            }

        }
    }
}
