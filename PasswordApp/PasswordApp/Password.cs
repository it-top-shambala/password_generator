using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApp
{
    public class Password
    {
        private string password { get; set; }

        public Password ()
        {
            password = "";
        }

        public string SetPassword (string value)
        {
            return string.Concat(password, value);
        }

        public void PasswordGeneration(int numberLetters, int numberSymbols, int numberDigits)
        {
           
            Task[] taskLetters = new Task[numberLetters];
            for (var i = 0; i < numberLetters; i++)
            {
                taskLetters[i] = Task.Factory.StartNew(() =>
                {
                    Letter symbol = new Letter();
                    symbol.Generating();
                    password = SetPassword( symbol.CodeSumbol.ToString());
                    Console.WriteLine($"Letter = {symbol.CodeSumbol} / Password - {password} ");

                });
            }
        
            Task[] taskSymbols = new Task[numberSymbols];
            for (var i = 0; i < numberSymbols; i++)
            {
                taskSymbols[i] = Task.Factory.StartNew(() =>
                {
                    Special symbol = new Special();
                    symbol.Generating();
                    password = SetPassword(symbol.CodeSumbol.ToString());
                    Console.WriteLine($"Special symbol = {symbol.CodeSumbol} / Password - {password}");
                });
                
            }
            Task[] taskDigits = new Task[numberDigits];
            for (var i = 0; i < numberDigits; i++)
            {
                taskDigits[i] = Task.Factory.StartNew(() =>
                {
                    Digit symbol = new Digit();
                    symbol.Generating();
                    password = SetPassword(symbol.CodeSumbol.ToString());
                    Console.WriteLine($"Digit = {symbol.CodeSumbol} / Password - {password}");
                });
            }
           
        }
    }
}
/*приложение для генерации пароля по заданному шамблону: количество букв, спец. символов, цифр, общая длина пароля

Каждая генерация - это отдельный поток*/