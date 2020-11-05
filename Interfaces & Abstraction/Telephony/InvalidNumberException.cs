using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class InvalidNumberException : Exception
    {
        private const string ExcMsg = "Invalid number!";

        public InvalidNumberException()
            : base(ExcMsg)
        {

        }

        public InvalidNumberException(string message)
            : base(message)
        {

        }
    }
}
