using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordApp
{
    public class Digit : Symbol
    {
        readonly Random x = new Random();
        public override void Generating()
        { 
            CodeSumbol =(char)x.Next(48, 57);
        }
    }
}
