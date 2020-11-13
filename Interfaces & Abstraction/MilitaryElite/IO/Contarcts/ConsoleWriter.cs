using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.IO.Contarcts
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text); ;
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
