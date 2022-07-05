using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordApp
{
    public class Password
    {
        private char _Letter { get; set; }
        private char _Symbol { get; set; }
        private int _Digit { get; set; }

        private string GeneratedPassword { get; set; }

       public Password (char Letter, char Symbol, int Digit)
        {
            _Letter = Letter;
            _Symbol = Symbol;
            _Digit = Digit;
            GeneratedPassword = string.Concat(_Letter, _Symbol, _Digit);
        }
         public string GetPassword()
        {
            return GeneratedPassword;
        }

    }
}
/*приложение для генерации пароля по заданному шамблону: количество букв, спец. символов, цифр, общая длина пароля

Каждая генерация - это отдельный поток*/