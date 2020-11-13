using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.IO.Contarcts
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
