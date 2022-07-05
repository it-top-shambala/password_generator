using System;

namespace PasswordApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Password password = new Password('S','^', 1);

            Console.WriteLine(password.GetPassword());

            Console.ReadKey();

        }
    }
}
