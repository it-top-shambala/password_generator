using System;
using System.Threading.Tasks;

namespace PasswordApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" * Генерация пароля * ");
            Password password = new Password();
            password.PasswordGeneration(5, 5, 2);
            Console.ReadKey();
        }
    }
}
